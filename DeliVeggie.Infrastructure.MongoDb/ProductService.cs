using DeliVeggie.Shared.Models.Entities;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.MongoDb
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _product;
        public ProductService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ADDB");
            _product = database.GetCollection<Product>("Products");
            
            //One Time Only
            //_product.SeedInitialData();            
        }
        public async Task<List<ProductResponse>> GetAllAsync()
        {
            var unMappedProducts = await _product.Find(c => true).ToListAsync();
            var response = unMappedProducts.Select(x => new ProductResponse
            {
                 Id = x.Id,
                 Name = x.Name
            }).ToList();
            return response;
        }

        public async Task<ProductDetailsResponse> GetByIdAsync(ProductDetailsRequest request)
        {
            var x = await _product.Find(c => c.Id == request.Id).FirstOrDefaultAsync();
            var totalReductions = x.PriceReductions.Select(a => a.Reduction).Sum();
            var response = new ProductDetailsResponse
            {
                Id = x.Id,
                Name = x.Name,
                EntryDate = x.EntryDate,
                CurrentPrice = (x.Price - totalReductions)
            };
            return response;
        }
    }
}
