using FlowMeet.ServiceRendezVous.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMeet.ServiceRendezVous.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblyOf<Unit>()
                                .AddClasses(classes => classes.Where(type =>
                                            type.Name.EndsWith("Handler")))
                                .AsImplementedInterfaces()
                                .WithScopedLifetime());
            return services;
        }
    }
}
