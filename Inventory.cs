public class Inventory
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set;}
    public required ProductTypeId ProductType { get; set; }
    public DateTime DateStocked { get; set;}
}

public class ProductTypeId
{
    public int Id { get; set; }
    public required string Name { get; set; }
}