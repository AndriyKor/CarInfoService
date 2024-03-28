using GraphQL.Types;

namespace WebAPIGraphQL.Cars;

public class CarsSchema : Schema
{
    public CarsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<CarsQuery>();
        Mutation = serviceProvider.GetRequiredService<CarsMutation>();
    }
}