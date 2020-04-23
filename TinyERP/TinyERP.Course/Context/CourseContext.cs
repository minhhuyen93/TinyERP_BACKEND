using System.Data.Entity;
using TinyERP.Common.Contexts;
using TinyERP.Common.Helpers;

namespace TinyERP.Course.Context
{
    public class CourseContext : BaseDbContext
    {
        public CourseContext() : base(DatabaseHelper.GetConnection<CourseContext>()) { }
        public DbSet<Entities.Course> Courses { get; set; }
    }
}
