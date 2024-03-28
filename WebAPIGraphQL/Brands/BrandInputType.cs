using GraphQL.Types;

namespace WebAPIGraphQL.Brands;

public class BrandInputType : InputObjectGraphType
{
    public BrandInputType()
    {
        Name = "BrandInput";
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<NonNullGraphType<StringGraphType>>("description");
        Field<NonNullGraphType<IntGraphType>>("foundationYear");
    }
}