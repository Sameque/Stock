using DTO.Model.Products;
using System.Collections.Generic;

namespace DTO.Interfaces.Products
{
    public interface IProductNotificationList : INotifications<ProductModelRequest, IEnumerable<ProductModelResponse>>
    {
    }
}
