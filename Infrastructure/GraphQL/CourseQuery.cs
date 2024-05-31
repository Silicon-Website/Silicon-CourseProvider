using WebApi.Interfaces;

namespace Infrastructure.GraphQL
{
    public class CourseQuery
    {
        private readonly ICourseService _courseService;

        public CourseQuery(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [GraphQLName("getCourses")]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseService.GetAllCourses();
        }
    }
}
