using GraphQL.Types;
using Infrastructure;

namespace WebAPIGraphQL.Brands;

public class BrandsQuery : ObjectGraphType
{
    public BrandsQuery(CarInfoServiceDbContext dbContext)
    {
        Field<ListGraphType<BrandType>>("brands").Resolve(_ => dbContext.Brands.ToList());
    }
}