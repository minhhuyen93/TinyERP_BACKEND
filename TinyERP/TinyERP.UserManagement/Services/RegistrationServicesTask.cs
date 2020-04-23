using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Services
{
    internal class RegistrationServicesTask : IApplicationStartedTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<IUserService, UserService>();
        }
    }
}
