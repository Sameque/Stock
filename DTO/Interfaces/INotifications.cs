using System.Collections.Generic;
using System.Net;
namespace DTO.Interfaces
{
    public interface INotifications<TRequest, TResponse>
    {
        HttpStatusCode StatusCode { get; set; }
        string StatusDescription { get; set; }
        IEnumerable<string> ValidationList { get; set; }
        TRequest Request { get; set; }
        TResponse Response { get; set; }
    }
}
