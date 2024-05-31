

using WebApi.Interfaces;

namespace Infrastructure.GraphQL.Mutations
{
    public class CourseMutation(ICourseService courseService)
    {

        private readonly ICourseService _courseService = courseService;

        [GraphQLName("createCourse")]
        public async Task<Course> CreateCourse(CourseCreateRequest input)
        {
            return await _courseService.CreateCourse(input);
        }

        [GraphQLName("updateCourse")]
        public async Task<Course> UpdateCourse(CourseUpdateRequest input)
        {
            return await _courseService.UpdateCourse(input);
        }

        [GraphQLName("deleteCourse")]
        public async Task<bool> DeleteCourse(int id)
        {
            return await _courseService.DeleteCourse(id);
        }
    }
}