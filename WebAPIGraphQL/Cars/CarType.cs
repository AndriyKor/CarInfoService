using GraphQL.Types;
using Infrastructure.Entities;

namespace WebAPIGraphQL.Cars;

public class CarType : ObjectGraphType<Car>
{
    public CarType()
    {
        Name = "Car";
        Description = "Car Type";
        Field(b => b.Id, nullable: true).Description("Car Id");
        Field(b => b.Description, nullable: false).Description("Car Description");
        Field(b => b.ProductionYear, nullable: false).Description("Car Production Year");
        Field(b => b.Model, nullable: false).Description("Car Model");
        Field(b => b.BrandId, nullable: false).Description("Car Brand Id");
    }
}