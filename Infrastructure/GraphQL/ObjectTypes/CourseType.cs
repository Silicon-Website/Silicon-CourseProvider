using Infrastructure.Entities;

namespace Infrastructure.GraphQL.ObjectTypes
{
    public class CourseType : ObjectType<CourseEntity>
    {
        protected override void Configure(IObjectTypeDescriptor<CourseEntity> descriptor)
        {
            descriptor.Field(c => c.Id).Type<IntType>();
            descriptor.Field(c => c.IsBestSeller).Type<BooleanType>();
            descriptor.Field(c => c.Image).Type<StringType>();
            descriptor.Field(c => c.Title).Type<StringType>();
            descriptor.Field(c => c.Author).Type<StringType>();
            descriptor.Field(c => c.Price).Type<StringType>();
            descriptor.Field(c => c.DiscountPrice).Type<StringType>();
            descriptor.Field(c => c.Hours).Type<StringType>();
            descriptor.Field(c => c.LikesInProcent).Type<StringType>();
            descriptor.Field(c => c.LikesInNumbers).Type<StringType>();
        }
    }
}
