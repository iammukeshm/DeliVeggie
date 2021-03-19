using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Publisher : IPublisher
    {
        private readonly IBus _bus;

        public Publisher()
        {
            _bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");
        }

        public async Task<IResponse> Request(IRequest request)
        {
            return await _bus.Rpc.RequestAsync<IRequest, IResponse>(request);
        }
    }
}