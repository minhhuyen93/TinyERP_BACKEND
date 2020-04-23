using TinyERP.Common.Configurations;
using TinyERP.Common.DI;
using TinyERP.Common.Enums;
using TinyERP.Common.Tasks;
using TinyERP.UserManagement.Share;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.UserManagement.Facades
{
    internal class RegistrationFacadesTask : IApplicationStartedTask
    {
        public void Execute(object arg = null)
        {
            ModuleDeploymentMode mode = ApplicationConfiguration.Instance.UserManagement.Mode;
            if (mode == ModuleDeploymentMode.InApp)
            {
                IoC.RegisterTransient<IUserFacade, UserFacade>();
            }
        }
    }
}
