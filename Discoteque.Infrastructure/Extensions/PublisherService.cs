namespace Discoteque.Infrastructure.Extensions
{
    using Confluent.Kafka;
    using Discoteque.Domain.Album.Entities;
    using Discoteque.Infrastructure.MessageBroker.Kafka.Config;
    using Domain.Shared.Events;
    using MessageBroker.Kafka;
    using MessageBroker.Kafka.Builders.Album;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class PublisherService
    {
        public static IServiceCollection AddPublishers(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var publisherConfig = new ProducerConfig();

            configuration.GetSection("KafkaConfiguration:Publisher").Bind(publisherConfig);
            services.Configure<KafkaTopics>(configuration.GetSection("KafkaConfiguration:Publisher:Topics"));

            services.AddSingleton(new ProducerBuilder<string, string>(publisherConfig).Build());

            services.AddScoped<IGenericEventBuilder<Album>, AlbumCreatedBuilder>();
            services.AddScoped<IPublisher<string>, StringPublisher>();

            return services;
        }
    }
}
