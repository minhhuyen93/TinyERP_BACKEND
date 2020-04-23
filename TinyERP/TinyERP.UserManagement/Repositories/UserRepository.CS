using System.Linq;
using TinyERP.UserManagement.Context;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private UserContext context;
        public UserRepository()
        {
            this.context = new UserContext();
        }
        public User Create(User user)
        {
            this.context.Users.Add(user);
            this.context.SaveChanges();
            return user;
        }

        public User GetById(int id)
        {
            return this.context.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
