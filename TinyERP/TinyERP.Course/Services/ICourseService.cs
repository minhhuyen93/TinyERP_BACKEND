using System.Threading.Tasks;
using TinyERP.Course.Dtos;

namespace TinyERP.Course.Services
{
    public interface ICourseService
    {
        Task<Entities.Course> Create(CreateCourseDto request);
        Task<CourseDetail> GetCourseDetail(int id);
    }
}
