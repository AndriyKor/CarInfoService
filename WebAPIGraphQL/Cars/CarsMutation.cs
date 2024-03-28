using GraphQL;
using GraphQL.Types;
using Infrastructure;
using Infrastructure.Entities;

namespace WebAPIGraphQL.Cars;

public class CarsMutation : ObjectGraphType
{
    public CarsMutation(CarInfoServiceDbContext dbContext)
    {
        Field<CarType>("createCar")
            .Argument<NonNullGraphType<CarInputType>>("car")
            .ResolveAsync(async context =>
            {
                var car = context.GetArgument<Car>("car");
                await dbContext.Cars.AddAsync(car);
                await dbContext.SaveChangesAsync();
                
                return car;
            });
    }
}