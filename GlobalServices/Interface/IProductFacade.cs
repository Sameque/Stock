using DTO.Interfaces.Products;
using DTO.Model.Products;

namespace GlobalServices.Interface
{
    public interface IProductFacade : IFacade<IProductNotification, ProductModelRequest, ProductModelResponse>
    {
    }
}
