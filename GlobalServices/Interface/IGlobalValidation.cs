using System.Collections.Generic;

namespace GlobalServices.Interface
{
    public interface IGlobalValidation<TRequest>
    {
        ICollection<string> Validation(TRequest request);
    }
}
