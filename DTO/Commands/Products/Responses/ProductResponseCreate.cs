using System;

namespace DTO.Commands.Products.Responses
{
    public class ProductResponseCreate : ProductResponse
    {
        public long Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }
    }
}
