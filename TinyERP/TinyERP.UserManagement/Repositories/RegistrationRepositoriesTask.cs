﻿using TinyERP.Common.DI;
using TinyERP.Common.Tasks;

namespace TinyERP.UserManagement.Repositories
{
    internal class RegistrationRepositoriesTask : IApplicationStartedTask
    {
        public void Execute(object arg = null)
        {
            IoC.RegisterTransient<IUserRepository, UserRepository>();
        }
    }
}
