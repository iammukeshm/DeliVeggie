using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public class Publisher : IPublisher
    {
        private readonly IBus _bus;
        public Publisher()
        {
            _bus = RabbitHutch.CreateBus("host=localhost;username=guest;password=guest");            
        }

        public IResponse RequestForAllProducts(ProductsRequest request)
        {
            return _bus.Rpc.Request<ProductsRequest, IResponse>(request);

        }

        public IResponse RequestProductDetails(ProductDetailsRequest request)
        {
            return _bus.Rpc.Request<ProductDetailsRequest, IResponse>(request);
        }
    }
}
