using GraphQL.Types;

namespace WebAPIGraphQL.Brands;

public class BrandsSchema : Schema
{
    public BrandsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<BrandsQuery>();
        Mutation = serviceProvider.GetRequiredService<BrandsMutation>();
    }
}