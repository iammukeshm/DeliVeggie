using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Publisher : IPublisher
    {
        public readonly IBus _bus;

        public Publisher()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public IResponse Request(IRequest request)
        {
            return _bus.Request<IRequest, IResponse>(request);
        }
    }
}