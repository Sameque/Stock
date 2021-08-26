using DTO.Interfaces;

namespace GlobalServices.Interface
{
    public interface IFacade<TNotification,TRequest, TResponse>
    {
        TNotification Create(TRequest request);
    }
}
