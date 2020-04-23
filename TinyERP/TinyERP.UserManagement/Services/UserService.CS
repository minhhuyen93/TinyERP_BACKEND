using System.Collections.Generic;
using System.Linq;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Validations;
using TinyERP.UserManagement.Entities;
using TinyERP.UserManagement.Repositories;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Services
{
    internal class UserService : IUserService
    {
        public int CreateAuthor(AuthorDto request)
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
        public AuthorInfo GetAuthorInfo(int id)
        {
            IUserRepository repo = IoC.Resolve<IUserRepository>();
            User user = repo.GetById(id);
            if (user == null)
            {
                throw new ValidationException("user.userDeTail.authorInvalid");
            }
            AuthorInfo author = new AuthorInfo();
            author.Id = user.Id;
            author.FirstName = user.FirstName;
            author.LastName = user.LastName;
            return author;
        }
    }
}
