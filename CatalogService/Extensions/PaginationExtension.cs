using CatalogService.API.Models;

namespace CatalogService.API.Extensions
{
    public static class PaginationExtension
    {
        public static readonly int maxPageSize = 15;
        public static PaginationResponse<T> WithPagination<T>(this ICollection<T> data, PaginationRequest paginationRequest)
        {
            var dataCount = data.Count;

            if (paginationRequest.Page < 1)
            {
                paginationRequest.Page = 1;
            }
            if (paginationRequest.Page > maxPageSize)
            {
                paginationRequest.Page = maxPageSize;
            }
            var skip = (paginationRequest.Page - 1) * maxPageSize;
            var pagedData = data.Skip(skip).Take(maxPageSize).ToList();
            var pagination = new PaginationResponse<T>
            {
                Data = pagedData,
                ShownDataCount = pagedData.Count,
                TotalDataCount = dataCount,
                CurrentPage = paginationRequest.Page,
            };
            return pagination;
        }
    }
}
