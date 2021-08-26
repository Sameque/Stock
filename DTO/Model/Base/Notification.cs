using System.Collections.Generic;
using System.Net;

namespace DTO.Model.Base
{
    public class Notification
    {
        public Notification()
        {
            ValidationList = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public IEnumerable<string> ValidationList { get; set; }
    }
}
