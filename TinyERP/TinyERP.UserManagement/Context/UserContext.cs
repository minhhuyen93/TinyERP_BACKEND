using System.Data.Entity;
using TinyERP.Common.Contexts;
using TinyERP.Common.Helpers;
using TinyERP.UserManagement.Entities;

namespace TinyERP.UserManagement.Context
{
    public class UserContext : BaseDbContext
    {
        public UserContext() : base(DatabaseHelper.GetConnection<UserContext>()) { }
        public DbSet<User> Users { get; set; }
    }
}
