using FlowMeet.Notification.Application.Common.Interfaces;
using FlowMeet.Notification.Domain.Common;
using FlowMeet.Notification.Infrastructure.Data.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMeet.Notification.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static async Task Migrate(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            FlowMeetNotificationDbContext dbContext =
               scope.ServiceProvider.GetRequiredService<FlowMeetNotificationDbContext>();

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
