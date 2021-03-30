using DeliVeggie.Shared.Models.Requests;
using DeliVeggie.Shared.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggie.Infrastructure.MongoDb
{
    //I should Probably move this to a Shared Project where all the Interfaces will live. This should make the application more scalable and open to more data providers in the future.
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllAsync();
        Task<ProductDetailsResponse> GetByIdAsync(ProductDetailsRequest request);
    }
}
