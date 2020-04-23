using System.Collections.Generic;
using System.Net;
using TinyERP.Common.Validations;

namespace TinyERP.Common.Data
{
    public class ResponseData<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public IList<Error> Errors { get; set; }
        public T Data { get; set; }
    }
}
