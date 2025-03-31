namespace NC2025_MinimalAPI_NET9.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // One-to-Many relationship
        public List<Product> Products { get; set; } = new();
    }
}