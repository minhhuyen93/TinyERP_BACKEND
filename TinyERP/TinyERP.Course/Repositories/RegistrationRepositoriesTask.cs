using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.Course.Repositories
{
    internal class RegistrationRepositoriesTask : IApplicationStartedTask
    {
        public void Execute(object args = null)
        {
            IoC.RegisterTransient<ICourseRepository, CourseRepository>();
        }
    }
}
