namespace Discoteque.Infrastructure.MessageBroker.Kafka.Builders.Album
{
    using Domain.Shared.Events;
    using Domain.Album.Entities;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using MessageBroker.Kafka.Config;
    using System.Text.Json;

    public class AlbumCreatedBuilder : IGenericEventBuilder<Album>
    {
        private readonly ILogger<AlbumCreatedBuilder> _logger;
        private readonly IPublisher<string> _publisher;
        private readonly string _topicName;

        public AlbumCreatedBuilder(ILogger<AlbumCreatedBuilder> logger,
            IOptions<KafkaTopics> kafkaTopicsConfiguration,
            IPublisher<string> kafkaPublisher)
        {
            _logger = logger;
            var topics = kafkaTopicsConfiguration.Value;
            _topicName = topics.AlbumsTopic;
            _publisher = kafkaPublisher;
        }
        public async Task PublishAsync(Album record)
        {
            _logger.LogInformation("Generating event for Album Created {operatingParameter}", record);
            _logger.LogInformation("topic name:{_topicName}", _topicName);
            var body = JsonSerializer.Serialize(record);
            await _publisher.PublishAsync(body, _topicName);
            _logger.LogInformation("Process complete, Album created successfully published");
        }
    }
}