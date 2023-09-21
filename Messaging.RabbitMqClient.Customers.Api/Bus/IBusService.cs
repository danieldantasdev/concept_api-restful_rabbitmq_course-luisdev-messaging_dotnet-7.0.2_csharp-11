namespace Messaging.RabbitMqClient.Customers.Api.Bus
{
    public interface IBusService
    {
        void Publish<T>(string routingKey, T message);
    }
}
