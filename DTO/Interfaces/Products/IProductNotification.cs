using DTO.Model.Products;

namespace DTO.Interfaces.Products
{
    public interface IProductNotification : INotifications<ProductModelRequest, ProductModelResponse>
    {
    }
}
