using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApi.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateCourse(CourseCreateRequest request);
        Task<Course> UpdateCourse(CourseUpdateRequest request);
        Task<IEnumerable<Course>> GetAllCourses();
        Task<bool> DeleteCourse(int id);
    }

    public class CourseService(IDbContextFactory<ApplicationDbContext> contextFactory) : ICourseService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;





        public async Task<Course> CreateCourse(CourseCreateRequest request)
        {
            await using var context = _contextFactory.CreateDbContext();

            var courseEntity = CourseFactory.Create(request);
            context.Courses.Add(courseEntity);
            await context.SaveChangesAsync();

            return CourseFactory.Create(courseEntity);
        }

        public async Task<Course> UpdateCourse(CourseUpdateRequest request)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existingCourse = await context.Courses.FirstOrDefaultAsync(c => c.Id == request.Id);

            if (existingCourse == null)
            {
                return null!;
            }

            var updatedCourseEntity = CourseFactory.Create(request);
            updatedCourseEntity.Id = existingCourse.Id;
            context.Entry(existingCourse).CurrentValues.SetValues(updatedCourseEntity);

            await context.SaveChangesAsync();
            return CourseFactory.Create(existingCourse);
        }

        public async Task<bool> DeleteCourse(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntity = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (courseEntity == null)
            {
                return false;
            }

            context.Courses.Remove(courseEntity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            await using var context = _contextFactory.CreateDbContext();
            var courseEntities = await context.Courses.ToListAsync();
            return courseEntities.Select(CourseFactory.Create);
        }
    }
}
