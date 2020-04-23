using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Enums;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Share.Facade
{
    internal class RegistrationRemoteFacadeTask : IApplicationStartedTask
    {
        public void Execute(object args = null)
        {
            ModuleDeploymentMode mode = ApplicationConfiguration.Instance.UserManagement.Mode;
            if (mode == ModuleDeploymentMode.ReMote)
            {
                IoC.RegisterTransient<IUserFacade, UserRemoteFacade>();
            }
        }
    }
}
