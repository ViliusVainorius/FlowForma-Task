namespace WebApi.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public ProductType Type { get; set; }

    }

    public class Clothing : Product
    {
        public float? Lenght { get; set; }
        public float? Diameter { get; set; }
    }

    public class Shoes : Product
    {
        public string? Brand { get; set; }
        public float? Size { get; set; }
    }

    public enum ProductType
    {
        Clothing,
        Shoes
    }
}
