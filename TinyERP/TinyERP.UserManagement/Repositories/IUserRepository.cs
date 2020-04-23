using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetById(int id);
    }
}
