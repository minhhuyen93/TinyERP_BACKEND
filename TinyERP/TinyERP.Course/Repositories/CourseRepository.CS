using System.Linq;
using TinyERP.Course.Context;

namespace TinyERP.Course.Repositories
{
    internal class CourseRepository : ICourseRepository
    {
        public Entities.Course Create(Entities.Course course)
        {
            CourseContext context = new CourseContext();
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public Entities.Course GetCourseByName(string name)
        {
            CourseContext context = new CourseContext();
            return context.Courses.FirstOrDefault(x => x.Name == name);
        }
        public Entities.Course GetById(int id)
        {
            CourseContext context = new CourseContext();
            return context.Courses.FirstOrDefault(x => x.Id == id);
        }
    }
}
