using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Stock.Interface
{
    public  interface IRepository<T>
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<T> GetByCode(long code);
        Task<IEnumerable<T>> GetAll();
    }
}
