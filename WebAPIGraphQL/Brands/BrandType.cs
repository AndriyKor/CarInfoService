using GraphQL.Types;
using Infrastructure.Entities;

namespace WebAPIGraphQL.Brands;

public class BrandType : ObjectGraphType<Brand>
{
    public BrandType()
    {
        Name = "Brand";
        Description = "Brand Type";
        Field(b => b.Id, nullable: true).Description("Brand Id");
        Field(b => b.Name, nullable: false).Description("Brand Name");
        Field(b => b.Description, nullable: false).Description("Brand Description");
        Field(b => b.FoundationYear, nullable: false).Description("Brand Foundation Year");
    }
}