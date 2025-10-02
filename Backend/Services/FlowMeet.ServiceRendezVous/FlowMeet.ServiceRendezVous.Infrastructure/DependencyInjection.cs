using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMeet.ServiceRendezVous.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan.FromAssemblyOf<FlowMeetServiceRendezVousDbContext>() // or any known type in your assembly
                    .AddClasses(classes => classes.Where(type =>
                                type.Name.EndsWith("Repository") ||
                                type.Name.EndsWith("Service")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
);
            services.AddDbContext<FlowMeetServiceRendezVousDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediator, Mediator>();

            return services;
        }
    }
}
