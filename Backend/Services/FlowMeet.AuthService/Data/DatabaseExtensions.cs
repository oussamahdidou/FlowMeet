using Microsoft.EntityFrameworkCore;

namespace FlowMeet.AuthService.Data
{
    public static class DatabaseExtensions
    {
        public static async Task Migrate(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            AuthDbContext dbContext =
               scope.ServiceProvider.GetRequiredService<AuthDbContext>();

            await dbContext.Database.MigrateAsync();
        }

    }
}
