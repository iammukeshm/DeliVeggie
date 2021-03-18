using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Subscriber
    {
        private readonly IBus _bus;
        public Subscriber()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }
    }
}
