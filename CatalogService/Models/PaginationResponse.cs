namespace CatalogService.API.Models
{
    public class PaginationResponse<T>
    {
        public List<T> Data { get; set; }
        public int ShownDataCount { get; set; }
        public int TotalDataCount { get; set; }
        public int CurrentPage { get; set; }
    }
}
