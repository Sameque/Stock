using DTO.Interfaces.Products;
using DTO.Model.Base;
using System.Collections.Generic;

namespace DTO.Model.Products
{
    public class ProductNotification : Notification, IProductNotification
    {
        public ProductNotification()
        {
            Request = new();
            Response = new ProductModelResponse();
        }

        public ProductModelRequest Request { get; set; }
        public ProductModelResponse Response { get; set; }
    }
}
