using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Stock.Interface
{
    public interface IRepositoryService<TNotification, TRequest,TResponse>
    {
        Task<TNotification> CreateAsync(TRequest obj);
        Task<TNotification> UpdateAsync(TRequest obj);
        Task<string> DeleteAsync(int id);
        Task<TNotification> GetByIdAsync(int id);
    }
}
