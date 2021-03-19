using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Subscriber : ISubscriber
    {
        private readonly IBus _bus;

        public Subscriber()
        {
            _bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");
        }
        public void Subscribe(Func<IRequest, IResponse> data)
        {
            _bus.Rpc.Respond(data);
        }
    }
}