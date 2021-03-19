using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DeliVeggie.Microservice.Products
{
    class Program
    {
        private static ServiceProvider _services;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            _services = new ServiceCollection().AddSingleton<ISubscriber, Subscriber>().BuildServiceProvider();
            var bus = _services.GetService<ISubscriber>();
            while (true)
            {
                bus?.Subscribe(RespondToProductDetailsRequest);
            }
        }

        private static IResponse RespondToProductsRequest(ProductDetailsRequest arg)
        {
            Console.WriteLine($"Receiving RespondToProductsRequest");
            var productList = new List<ProductResponse>();
            productList.Add(new ProductResponse { Id ="1", Name = "Pepsi" });
            productList.Add(new ProductResponse { Id = "2", Name = "Sprite" });
            IResponse data = new Response<List<ProductResponse>>() { Data = productList };
            return data;
        }

        private static IResponse RespondToProductDetailsRequest(ProductDetailsRequest arg)
        {
            Console.WriteLine($"Receiving RespondToProductsRequest");
            var details = new ProductDetailsResponse() { Id = "1", Name = "Pepsi", CurrentPrice = 500, EntryDate = DateTime.Now };
            IResponse data = new Response<ProductDetailsResponse>() { Data = details };
            return data;
        }
    }
}
