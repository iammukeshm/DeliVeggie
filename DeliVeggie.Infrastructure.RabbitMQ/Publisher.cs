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
            _bus = RabbitHutch.CreateBus("host=localhost");            
        }

        public IEnumerable<ProductResponse> RequestForAllProducts(ProductsRequest request)
        {
            return _bus.Rpc.Request<ProductsRequest, IEnumerable<ProductResponse>>(request);

        }

        public ProductDetailsResponse RequestProductDetails(ProductDetailsRequest request)
        {
            return _bus.Rpc.Request<ProductDetailsRequest, ProductDetailsResponse>(request);
        }
    }
}
