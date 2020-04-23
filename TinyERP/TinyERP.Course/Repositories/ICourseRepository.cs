namespace TinyERP.Course.Repositories
{
    public interface ICourseRepository
    {
        Entities.Course GetCourseByName(string name);
        Entities.Course Create(Entities.Course course);
        Entities.Course GetById(int id);
    }
}
