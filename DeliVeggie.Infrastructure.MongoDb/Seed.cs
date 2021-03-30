using DeliVeggie.Shared.Models.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliVeggie.Infrastructure.MongoDb
{
    public static class Seed
    {
        public static void SeedInitialData(this IMongoCollection<Product> collection)
        {
            collection.InsertOne(new Product 
            { 
                Id = Guid.NewGuid().ToString(), 
                Name = "Pepsi", 
                Price = 15, 
                EntryDate = DateTime.Now,
                 PriceReductions = new[]
                 {
                     new PriceReduction
                     {
                          DayOfWeek = 1,
                          Reduction = 1,
                     },
                     new PriceReduction
                     {
                          DayOfWeek = 2,
                          Reduction = 0.5,
                     },
                 }
            });
            collection.InsertOne(new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = "7Up",
                Price = 17.5,
                EntryDate = DateTime.Now,
                PriceReductions = new[]
                 {
                     new PriceReduction
                     {
                          DayOfWeek = 1,
                          Reduction = 0.5,
                     },
                     new PriceReduction
                     {
                          DayOfWeek = 2,
                          Reduction = 0.1,
                     },
                 }
            });
        }
    }
}
