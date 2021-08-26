using DTO.Commands.Products.Requests;
using DTO.Commands.Products.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalServices.Interface
{
    public interface IProductHandler
    {
        Task<ProductResponseCreate> Handler(ProductRequestCreate request);
        Task<ProductResponseUpdate> Handler(ProductRequestUpdate request);
        Task<ProductResponseDelete> Handler(ProductRequestDelete request);
        Task<ProductResponseFind> Handler(ProductRequestFind request);
        Task<IEnumerable<ProductResponseFind>> Handler();
    }
}
