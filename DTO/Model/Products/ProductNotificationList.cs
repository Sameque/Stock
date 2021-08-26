using DTO.Interfaces.Products;
using DTO.Model.Base;
using System.Collections.Generic;

namespace DTO.Model.Products
{
    public class ProductNotificationList : Notification, IProductNotificationList
    {
        public ProductModelRequest? Request { get; set; }
        public IEnumerable<ProductModelResponse>? Response { get; set; }
    }
}
