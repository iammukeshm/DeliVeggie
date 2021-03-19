﻿using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace DeliVeggie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublisher _publisher;

        public ProductsController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]
        public IActionResult GetAllAsync()
        {
            var request = new ProductsRequest();
            var data = _publisher.RequestForAllProducts(request);
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdAsync(string id)
        {
            var request = new ProductDetailsRequest() { Id = id };
            if (!(_publisher.RequestProductDetails(request) is Response<ProductDetailsResponse> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
    }
}
