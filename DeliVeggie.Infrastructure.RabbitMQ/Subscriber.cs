using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System;

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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _bus?.Dispose();

            _disposed = true;
        }
    }
}