namespace Infrastructure.Entities;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int FoundationYear { get; set; }
    public virtual List<Car> Cars { get; set; }
}