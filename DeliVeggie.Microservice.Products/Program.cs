using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using Microsoft.Extensions.DependencyInjection;
using System;

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
                bus?.Subscribe(Respond);
            }
        }

        private static IResponse Respond(ProductDetailsRequest arg)
        {
            Console.WriteLine($"Receiving request");
            return default;
        }
    }
}
