using DeliVeggie.Infrastructure.RabbitMQ;
using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var request = new Request<ProductsRequest>() { Data = new ProductsRequest()};
            var data = _publisher.Request(request);
            if (!(data is Response<List<ProductResponse>> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdAsync(string id)
        {
            var request = new Request<ProductDetailsRequest>() { Data  = new ProductDetailsRequest() { Id = id }};
            var message = _publisher.Request(request);
            if (!(message is Response<ProductDetailsResponse> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
    }
}