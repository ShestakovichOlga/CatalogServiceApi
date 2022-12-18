namespace CatalogService.API.Models
{
    public class ItemPaginationRequest : PaginationRequest
    {
        public Guid? CategoryId { get; set; }
    }
}
