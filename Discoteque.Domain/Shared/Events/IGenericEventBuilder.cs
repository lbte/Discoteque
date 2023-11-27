namespace Discoteque.Domain.Shared.Events
{
    public interface IGenericEventBuilder<in T>
    {
        Task PublishAsync(T record);
    }
}
