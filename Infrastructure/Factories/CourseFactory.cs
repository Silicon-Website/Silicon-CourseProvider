
using Infrastructure.Entities;

public static class CourseFactory
{
    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            IsBestSeller = request.IsBestSeller,
            Image = request.Image,
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            Hours = request.Hours,
            LikesInProcent = request.LikesInProcent,
            LikesInNumbers = request.LikesInNumbers
        };
    }


    public static CourseEntity Create(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            IsBestSeller = request.IsBestSeller,
            Image = request.Image,
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            Hours = request.Hours,
            LikesInProcent = request.LikesInProcent,
            LikesInNumbers = request.LikesInNumbers
        };
    }


    public static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            IsBestSeller = entity.IsBestSeller,
            Image = entity.Image,
            Title = entity.Title,
            Author = entity.Author,
            Price = entity.Price,
            DiscountPrice = entity.DiscountPrice,
            Hours = entity.Hours,
            LikesInProcent = entity.LikesInProcent,
            LikesInNumbers = entity.LikesInNumbers
        };
    }
}
