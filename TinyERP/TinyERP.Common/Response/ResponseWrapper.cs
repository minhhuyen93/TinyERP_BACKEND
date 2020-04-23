using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using TinyERP.Common.Data;
using TinyERP.Common.Validations;

namespace TinyERP.Common.Response
{
    public class ResponseWrapper : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            ResponseData<object> response = new ResponseData<object>();
            if (context.Exception != null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }
            if (context.Exception != null && context.Exception is ValidationException)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Errors = ((ValidationException)context.Exception).Errors;
            }
            if (context.Response != null && context.Response.StatusCode != HttpStatusCode.NoContent)
            {
                response.StatusCode = HttpStatusCode.OK;
                ObjectContent objectData = (ObjectContent)context.Response.Content;
                response.Data = objectData.Value;
            }
            else
            {
                response.StatusCode = HttpStatusCode.OK;
            }

            context.Response = context.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
