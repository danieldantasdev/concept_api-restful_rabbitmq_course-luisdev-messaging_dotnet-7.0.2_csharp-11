﻿namespace Messaging.EasyNetQ.Customers.Api.Bus
{
    public interface IBusService
    {
        void Publish<T>(string routingKey, T message);
    }
}
