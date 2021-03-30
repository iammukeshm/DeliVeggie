using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Subscriber : ISubscriber
    {
        public readonly IBus _bus;

        public Subscriber()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }
        public void Subscribe(Func<IRequest, IResponse> data)
        {
             _bus.Respond<IRequest, IResponse>(data);
        }
    }
}