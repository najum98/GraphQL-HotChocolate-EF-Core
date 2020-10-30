using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace ContosoUniversity
{
    public class Query
    {
        [UseFirstOrDefault]
        [UseSelection]
        public IQueryable<Student> GetStudentById([Service]SchoolContext context, int studentId) =>
            context.Students.Where(t => t.Id == studentId);
        
        [UsePaging] //Middleware order is important
        [UseSelection]//The most top field middleware is actually applied last
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> GetStudents([Service]SchoolContext context) =>
            context.Students;

        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Course> GetCourses([Service]SchoolContext context) =>
            context.Courses;
    }
}