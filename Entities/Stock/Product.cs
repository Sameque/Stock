using Entities.Base;

namespace Entities.Stock
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Code = 0;
            Description = "";
            Amount = 0;
        }
        public long Code { get; set; }
        public string Description { get; set; }
        public int? Amount { get; set; }
    }
}