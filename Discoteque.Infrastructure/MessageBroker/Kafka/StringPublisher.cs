namespace Discoteque.Infrastructure.MessageBroker.Kafka
{
    using Confluent.Kafka;
    using Microsoft.Extensions.Logging;

    public class StringPublisher : IPublisher<string>
    {
        private readonly IProducer<string, string> _kafkaPublisher;
        private readonly ILogger<StringPublisher> _logger;

        public StringPublisher(IProducer<string, string> kafkaPublisher, ILogger<StringPublisher> logger)
        {
            _kafkaPublisher = kafkaPublisher;
            _logger = logger;
        }

        public async Task PublishAsync(string message, string id, string topicName)
        {
            _logger.LogInformation("Publishing event with id {id} into topic {topic}", id, topicName);
            await _kafkaPublisher.ProduceAsync(topicName, new()
            {
                Key = id,
                Value = message
            });
            _logger.LogInformation("Event with id {id} successfully published", id);
        }
    }
}