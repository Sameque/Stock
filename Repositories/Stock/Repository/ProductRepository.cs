using Entities.Stock;
using Repositories.Stock.Interface;
using RepositoryEF.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Stock.Repository
{
    public class ProductRepository : IProductRepository
    {
        //private readonly IDbConnection _context;
        private readonly RepositoryEFContext _context;

        public ProductRepository(RepositoryEFContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product entity)
        {
            try
            {
                _ = _context.AddAsync(entity);
                _ = _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<Product> GetById(int id)
        {
            throw new System.NotImplementedException();
            //return _context.Products.Find(id);
        }

        public async Task<Product> GetByCode(long code)
        {
            return await _context.Products.Where(p => p.Code == code).FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _ = _context.Update(entity);
            _ = _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var response = _context.Products.ToList<Product>();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
