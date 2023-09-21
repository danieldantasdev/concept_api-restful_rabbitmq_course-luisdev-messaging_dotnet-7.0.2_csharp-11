namespace Messaging.MassTransit.Customers.Api.Bus
{
    public interface IBusService
    {
        Task Publish<T>(T message);
    }
}

