using System;

namespace DTO.Commands.Products.Responses
{
    public class ProductResponseFind : ProductResponse
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        //public bool Deleted { get; set; }
    }
}
