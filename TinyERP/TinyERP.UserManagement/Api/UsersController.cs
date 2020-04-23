using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Response;
using TinyERP.UserManagement.Services;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Api
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public int CreateAuthor(AuthorDto request)
        {
            IUserService service = IoC.Resolve<IUserService>();
            return service.CreateAuthor(request);
        }
        [Route("{id}/authorInfo")]
        [HttpGet()]
        [ResponseWrapper()]
        public AuthorInfo GetAuthorInfo(int id)
        {
            IUserService service = IoC.Resolve<IUserService>();
            return service.GetAuthorInfo(id);
        }
    }
}
