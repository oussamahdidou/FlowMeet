using KafkaFlow;
using KafkaFlow.Configuration;
using KafkaFlow.Serializer;

namespace FlowMeet.AuthService.Extensions
{
    public static class KafkaFlowExtensions
    {
        /// <summary>
        /// Adds a single consumer with specified topic, group, and handler.
        /// </summary>
        public static IClusterConfigurationBuilder AddConsumer<THandler>(
            this IClusterConfigurationBuilder cluster,
            string topic,
            string groupId,
            int bufferSize = 100,
            int workersCount = 10
        ) where THandler : class, IMessageHandler
        {
            cluster.AddConsumer(consumer => consumer
                .Topic(topic)
                .WithGroupId(groupId)
                .WithBufferSize(bufferSize)
                .WithWorkersCount(workersCount)
                .WithAutoOffsetReset(AutoOffsetReset.Earliest)
                .AddMiddlewares(middlewares => middlewares
                    .AddDeserializer<JsonCoreDeserializer>()
                    .AddTypedHandlers(handlers => handlers.AddHandler<THandler>())
                )
            );

            return cluster;
        }

        /// <summary>
        /// Adds a single producer with specified name and default topic.
        /// </summary>
        public static IClusterConfigurationBuilder AddProducer(
            this IClusterConfigurationBuilder cluster,
            string producerName,
            string defaultTopic
        )
        {
            cluster.AddProducer(producerName, producer => producer
                .DefaultTopic(defaultTopic)
                .AddMiddlewares(middlewares => middlewares
                    .AddSerializer<JsonCoreSerializer>()
                )
            );

            return cluster;
        }
    }

}
