namespace CatalogService.API.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
