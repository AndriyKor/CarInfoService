using GraphQL;
using GraphQL.Types;
using Infrastructure;
using Infrastructure.Entities;

namespace WebAPIGraphQL.Brands;

public class BrandsMutation : ObjectGraphType
{
    public BrandsMutation(CarInfoServiceDbContext dbContext)
    {
        Field<BrandType>("createBrand")
            .Argument<NonNullGraphType<BrandInputType>>("brand")
            .ResolveAsync(async context =>
            {
                var brand = context.GetArgument<Brand>("brand");
                await dbContext.Brands.AddAsync(brand);
                await dbContext.SaveChangesAsync();
                
                return brand;
            });
    }
}