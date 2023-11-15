namespace Discoteque.Infrastructure.MessageBroker.Kafka
{
    public interface IPublisher<in T>
    {
        Task PublishAsync(T message, string id, string topicName);
    }
}