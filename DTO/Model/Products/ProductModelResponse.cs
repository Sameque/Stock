using System;

namespace DTO.Model.Products
{
    public class ProductModelResponse
    {
        public int Id { get; set; }
        public long Code { get; set; }
        public string? Description { get; set; }
        public int? Amount { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; }
    }
}
