using System.Threading.Tasks;
using System.Web.Http;
using TinyERP.Common.DI;
using TinyERP.Common.Response;
using TinyERP.Course.Dtos;
using TinyERP.Course.Services;

namespace TinyERP.Course.Api
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        [Route("")]
        [HttpPost()]
        [ResponseWrapper()]
        public async Task<Entities.Course> CreateCourse(CreateCourseDto request)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            return await service.Create(request);
        }
        [Route("{id}")]
        [HttpGet()]
        [ResponseWrapper()]
        public async Task<CourseDetail> GetCourseDetail(int id)
        {
            ICourseService service = IoC.Resolve<ICourseService>();
            return await service.GetCourseDetail(id);
        }
    }
}
