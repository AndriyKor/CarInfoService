using GraphQL.Types;
using Infrastructure;

namespace WebAPIGraphQL.Cars;

public class CarsQuery : ObjectGraphType
{
    public CarsQuery(CarInfoServiceDbContext dbContext)
    {
        Field<ListGraphType<CarType>>("cars").Resolve(_ => dbContext.Cars.ToList());
    }
}