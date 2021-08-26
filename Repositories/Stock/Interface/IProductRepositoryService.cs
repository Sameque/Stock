using DTO.Interfaces.Products;
using DTO.Model.Products;
using Entities.Stock;
using System.Threading.Tasks;

namespace Repositories.Stock.Interface
{
    public interface IProductRepositoryService : IRepositoryService<IProductNotification, ProductModelRequest, ProductModelResponse>
    {
        Task<IProductNotification> GetByCodeAsync(long code);
        Task<int> AddAsync(int productId, int amount);
        Task<int> RemoveAsync(int productId, int amount);
        Task<IProductNotificationList> GetAllAsync();

    }
}
