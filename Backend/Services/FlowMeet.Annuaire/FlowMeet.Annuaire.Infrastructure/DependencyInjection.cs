using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using FlowMeet.Annuaire.Infrastructure.Extensions;
using KafkaFlow;
using KafkaFlow.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowMeet.Annuaire.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan.FromAssemblyOf<FlowMeetAnnuaireDbContext>() // or any known type in your assembly
                    .AddClasses(classes => classes.Where(type =>
                                type.Name.EndsWith("Repository") ||
                                type.Name.EndsWith("Service") ||
                                type.Name.EndsWith("Publisher")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
);
            services.AddKafka(kafka => kafka
               .UseConsoleLog()
               .AddCluster(cluster => cluster
                   .WithBrokers(new[] { configuration.GetConnectionString("MessageBroker") })
                   .AddProducer(KafkaProducers.RoleCreatedProducer.ToString(), KafkaTopics.RoleCreated.ToString())
                   .AddProducer(KafkaProducers.RoleAssignedToGroupProducer.ToString(), KafkaTopics.RoleAssignedToGroup.ToString())
                   .AddProducer(KafkaProducers.RoleRemovedFromGroupProducer.ToString(), KafkaTopics.RoleRemovedFromGroup.ToString())
                   )
                .AddOpenTelemetryInstrumentation()


           );

            services.AddDbContext<FlowMeetAnnuaireDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediator, Mediator>();
            return services;
        }
    }
}
