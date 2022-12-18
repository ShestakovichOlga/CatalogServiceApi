namespace CatalogService.API.Models
{
    public class ItemRequest
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
