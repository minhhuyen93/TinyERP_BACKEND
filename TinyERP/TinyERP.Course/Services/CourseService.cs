using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinyERP.Common.DI;
using TinyERP.Common.Helpers;
using TinyERP.Common.Validations;
using TinyERP.Course.Dtos;
using TinyERP.Course.Repositories;
using TinyERP.UserManagement.Share.Dtos;
using TinyERP.UserManagement.Share.Facade;

namespace TinyERP.Course.Services
{
    internal class CourseService : ICourseService
    {
        public async Task<Entities.Course> Create(CreateCourseDto request)
        {
            this.Validate(request);
            IUserFacade userFacade = IoC.Resolve<IUserFacade>();
            int authorId = await userFacade.CreateAuthor(request.Author);

            Entities.Course course = new Entities.Course()
            {
                Name = request.Name,
                Description = request.Description
            };
            course.AuthorId = authorId;
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            return repo.Create(course);
        }


        private void Validate(CreateCourseDto request)
        {
            IList<Error> errors = ValidationHelper.Validate(request);
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            Entities.Course course = repo.GetCourseByName(request.Name);
            if (course != null)
            {
                errors.Add(new Error("course.addCourse.nameWasExisted"));
            }
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }
        }
        public async Task<CourseDetail> GetCourseDetail(int id)
        {
            ICourseRepository repo = IoC.Resolve<ICourseRepository>();
            Entities.Course course = repo.GetById(id);
            if (course == null)
            {
                throw new ValidationException("course.courseDetail.courseNotExisted");
            }
            IUserFacade userFacade = IoC.Resolve<IUserFacade>();
            AuthorInfo author = await userFacade.GetAuthorInfo(course.AuthorId);
            CourseDetail courseDetail = new CourseDetail();
            courseDetail.Id = course.Id;
            courseDetail.Name = course.Name;
            courseDetail.Description = course.Description;
            courseDetail.Author = author;
            return courseDetail;
        }
    }
}
