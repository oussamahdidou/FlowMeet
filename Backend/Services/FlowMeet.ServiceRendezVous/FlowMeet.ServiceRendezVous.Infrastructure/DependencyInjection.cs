using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Infrastructure.Consumers;
using FlowMeet.ServiceRendezVous.Infrastructure.Data.DbContexts;
using FlowMeet.ServiceRendezVous.Infrastructure.Extensions;
using KafkaFlow;
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
                                type.Name.EndsWith("Service") ||
                                type.Name.EndsWith("Publisher")))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
);
            services.AddKafka(kafka => kafka
                    .UseConsoleLog()
                    .AddCluster(cluster => cluster
                        .WithBrokers(new[] { configuration.GetConnectionString("MessageBroker") })
                         .AddConsumer<TestEventHandler>("sample-topic", "sample-group")//
                         .AddProducer("producer-name", "sample-topic")
                    )
                );

            services.AddDbContext<FlowMeetServiceRendezVousDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Database"));

            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMediator, Mediator>();

            return services;
        }
    }
}
