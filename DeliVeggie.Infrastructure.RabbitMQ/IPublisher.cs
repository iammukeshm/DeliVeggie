using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Infrastructure.RabbitMQ
{
    public interface IPublisher
    {
        IResponse RequestForAllProducts(ProductsRequest request);
        IResponse RequestProductDetails(ProductDetailsRequest request);
    }
}
