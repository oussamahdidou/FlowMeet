using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMeet.Annuaire.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task Migrate(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using FlowMeetAnnuaireDbContext dbContext =
                scope.ServiceProvider.GetRequiredService<FlowMeetAnnuaireDbContext>();

            await dbContext.Database.MigrateAsync();
        }

        public static void UseEncryptedProperties(this ModelBuilder modelBuilder, IEncryptionService encryptionService)
        {
            var stringProperties = modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.ClrType.GetProperties()
                    .Where(p => p.IsDefined(typeof(EncryptedAttribute), inherit: true) && p.PropertyType == typeof(string)));

            foreach (var prop in stringProperties)
            {
                var entityType = modelBuilder.Model.FindEntityType(prop.DeclaringType);
                var property = entityType?.FindProperty(prop.Name);
                if (property != null)
                {
                    property.SetValueConverter(new ValueConverter<string, string>(
                        v => encryptionService.Encrypt(v),
                        v => encryptionService.Decrypt(v)));
                }
            }
        }
    }
}
