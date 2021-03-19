using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliVeggie.Microservice.Products
{
    internal class Program
    {
        private static ServiceProvider _services;

        private static void Main(string[] args)
        {
            Console.WriteLine("Product Microservice Started..");
            _services = new ServiceCollection().AddSingleton<ISubscriber>(x=> new Subscriber()).BuildServiceProvider();
            var bus = _services.GetService<ISubscriber>();
            while (true)
            {
                bus?.Subscribe(HandleRequest);
            }
        }
        private static IEnumerable<ProductResponse> productResponses = new List<ProductResponse>()
        {
            new ProductResponse{ Id = "1", Name = "Pepsi"},
            new ProductResponse{ Id = "2", Name = "7Up"},
            new ProductResponse{ Id = "3", Name = "Dew"},
            new ProductResponse{ Id = "4", Name = "Coke"}
        };

        private static IResponse HandleRequest(IRequest arg)
        {

            if (arg is Request<ProductDetailsRequest> detailsRequest)
            {
                Console.WriteLine($"Gateway sent a request to retrieve details of product with ID {detailsRequest.Data.Id}.");
                //var details = productResponses.Where(a => a.Id == detailsRequest.Data.Id).FirstOrDefault();
                var details = new ProductDetailsResponse() { Id = detailsRequest.Data.Id, Name = "Pepsi", CurrentPrice = 500, EntryDate = DateTime.Now };
                IResponse data = new Response<ProductDetailsResponse>() { Data = details };
                return data;
            }
            else
            {
                Console.WriteLine($"Gateway sent a request to retrieve all products.");
                IResponse data = new Response<List<ProductResponse>>() { Data = productResponses.ToList() };
                 return data;
            }

        }
    }
}