using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Validations;
using TinyERP.UserManagement.Entities;
using TinyERP.UserManagement.Repositories;
using TinyERP.UserManagement.Services;
using TinyERP.UserManagement.Share.Dtos;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.UserManagement.Facades
{
    internal class UserFacade : IUserFacade
    {
        public async Task<int> CreateAuthor(AuthorDto request)
        {
            this.Validate(request);
            User user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            IUserRepository repo = IoC.Resolve<IUserRepository>();
            user = repo.Create(user);
            return user.Id;
        }


        private void Validate(AuthorDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
        public async Task<AuthorInfo> GetAuthorInfo(int id)
        {
            IUserService service = IoC.Resolve<IUserService>();
            return service.GetAuthorInfo(id);
        }
    }
}
