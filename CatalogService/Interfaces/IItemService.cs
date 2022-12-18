using CatalogService.API.Models;

namespace CatalogService.API.Interfaces
{
    public interface IItemService
    {
        PaginationResponse<ItemResponse> GetItems(ItemPaginationRequest itemFilterPaginationRequest);
        ItemResponse GetItem(Guid id);
        ItemResponse AddItem(ItemRequest itemRequest);
        void UpdateItem(Guid id, ItemRequest itemRequest);
        void DeleteItem(Guid id);
    }
}
