using TinyERP.Common.Attributes;
using TinyERP.Course.Consts;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.Course.Dtos
{
    public class CreateCourseDto
    {
        [Required("course.addCourse.nameWasRequired")]
        [MinLength("course.addCourse.nameWasUnderMinLength", CourseValidationRules.Course_Name_Min_Length)]
        [MaxLength("course.addCourse.nameWasExceedMaxLength", CourseValidationRules.Course_Name_Max_Length)]
        public string Name { get; set; }
        public string Description { get; set; }
        public AuthorDto Author { get; set; }
    }
}
