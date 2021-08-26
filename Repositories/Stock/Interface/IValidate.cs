using System.Collections.Generic;

namespace Repositories.Stock.Interface
{
    public interface IValidate<T>
    {
        ICollection<string> Create(T obj);
        ICollection<string> Update(T obj);
        ICollection<string> Delete(int id);
        ICollection<string> Get(int id);
        ICollection<string> GetForCode(long code);
    }
}
