using System.Data.Entity;

namespace TinyERP.Common.Contexts
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(string connectionString) : base(connectionString) { }
    }
}
