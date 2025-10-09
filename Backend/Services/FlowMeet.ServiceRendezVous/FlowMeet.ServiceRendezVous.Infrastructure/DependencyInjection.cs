using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Infrastructure.Consumers;
using FlowMeet.ServiceRendezVous.Infrastructure.Data.DbContexts;
using KafkaFlow;
using KafkaFlow.Serializer;
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
            services.AddKafka(kafka => kafka
                    .UseConsoleLog()
                    .AddCluster(cluster => cluster
                        .WithBrokers(new[] { configuration.GetConnectionString("MessageBroker") })
                        .AddConsumer(consumer => consumer
                            .Topic("sample-topic")
                            .WithGroupId("sample-group")
                            .WithBufferSize(100)
                            .WithWorkersCount(10)
                            .AddMiddlewares(middlewares => middlewares
                                .AddDeserializer<JsonCoreDeserializer>()
                                .AddTypedHandlers(handlers => handlers
                                    .AddHandler<TestEventHandler>())
                            )
                        )
                        .AddProducer("producer-name", producer => producer
                            .DefaultTopic("sample-topic")
                            .AddMiddlewares(middlewares => middlewares
                                .AddSerializer<JsonCoreSerializer>()
                            )
                        )
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
