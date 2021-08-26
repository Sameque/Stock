using DTO.Interfaces.Products;
using DTO.Model.Products;
using System.Threading.Tasks;

namespace GlobalServices.Interface
{
    public interface IProductGlobalServices : IGlobalServices<ProductModelRequest, IProductNotification>
    {
        Task<int> CheckAmountAsync(int ProductId);
        Task<int> RemoveAsync(int id, int amount);
        Task<int> AddAsync(int id, int amount);
        Task<ProductModelResponse> GetByCodeAsync(long code);
    }
}
