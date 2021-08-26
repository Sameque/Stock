using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalServices.Interface
{
    public interface IGlobalServices<TRequest, TResponse>
    {
        Task<TResponse> CreateAsync(TRequest obj);
        Task<ICollection<TResponse>> FindAsync(TRequest obj);
        Task<TResponse> UpdateAsync(TRequest obj);
        Task<string> DeleteAsync(int id);
        //ICollection<string> Validate(TRequest obj);
    }
}