using GraphQL.Types;

namespace WebAPIGraphQL.Cars;

public class CarInputType : InputObjectGraphType
{
    public CarInputType()
    {
        Name = "CarInput";
        Field<NonNullGraphType<StringGraphType>>("description");
        Field<NonNullGraphType<IntGraphType>>("productionYear");
        Field<NonNullGraphType<StringGraphType>>("model");
        Field<NonNullGraphType<IntGraphType>>("brandId");
    }
}