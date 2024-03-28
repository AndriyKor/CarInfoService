namespace Infrastructure.Entities;

public class Car
{
    public int? Id { get; set; }
    public string Description { get; set; }
    public int ProductionYear { get; set; }
    public string Model { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }
}