using DTO.Model.Products;
using Entities.Stock;
using Repositories.Stock.Interface;
using System;
using System.Collections.Generic;

namespace Repositories.Stock.Validations
{
    public class ProductRepositoryValidate : IProductRepositoryValidate
    {
        public ICollection<string> Create(ProductModelRequest obj)
        {
            List<string> validates = new();

            if (obj.Code == 0)
                validates.Add($"Code invalido: {obj.Code}");

            if (string.IsNullOrWhiteSpace(obj.Description))
                validates.Add($"Description invalid: {obj.Description}");

            return validates;
        }

        public ICollection<string> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetForCode(long code)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> Update(ProductModelRequest obj)
        {
            throw new NotImplementedException();
        }
    }
}
