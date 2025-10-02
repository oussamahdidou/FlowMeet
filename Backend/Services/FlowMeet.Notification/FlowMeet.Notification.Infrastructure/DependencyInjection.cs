using FlowMeet.Notification.Application.Common.Interfaces;
using FlowMeet.Notification.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMeet.Notification.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan.FromAssemblyOf<FlowMeetNotificationDbContext>() // or any known type in your assembly
                    .AddClasses(classes => classes.Where(type =>
                                type.Name.EndsWith("Repository") ||
                                type.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
);
            services.AddDbContext<FlowMeetNotificationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediator, Mediator>();
            return services;
        }
    }
}
