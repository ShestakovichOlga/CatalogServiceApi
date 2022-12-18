using AutoMapper;
using CatalogService.API.Exceptions;
using CatalogService.API.Models;
using CatalogService.API.Extensions;
using CatalogService.API.Interfaces;

namespace CatalogService.API.Services
{
    public class ItemService : IItemService
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ItemService(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public ItemResponse AddItem(ItemRequest itemRequest)
        {
            var category = _categoryService.Categories.SingleOrDefault(x => x.Id == itemRequest.CategoryId);
            _ = category ?? throw new NotFoundException(ExceptionMessages.ItemNotFound);
            var item = _mapper.Map<Item>(itemRequest);
            category.Items.Add(item);
            return _mapper.Map<ItemResponse>(item);
          
        }
        public void DeleteItem(Guid id)
        {
            var item = _categoryService.Categories
               .SelectMany(x => x.Items)
               .SingleOrDefault(x => x.Id == id);
            _ = item ?? throw new NotFoundException(ExceptionMessages.ItemNotFound);
            var category = _categoryService.Categories.Single(x => x.Id == item.CategoryId);
            category.Items.Remove(item);
        }
        public ItemResponse GetItem(Guid id)
        {
            var itemResponse = _categoryService.Categories
                .SelectMany(x => x.Items)
                .Select(x => _mapper.Map<ItemResponse>(x))
                .SingleOrDefault(x => x.Id == id);
            _ = itemResponse ?? throw new NotFoundException(ExceptionMessages.ItemNotFound);
            return itemResponse;
        }
        public PaginationResponse<ItemResponse> GetItems(ItemPaginationRequest itemFilterPaginationRequest)
        {
            var categories = _categoryService.Categories.AsEnumerable();
            if (itemFilterPaginationRequest.CategoryId != null)
            {
                categories = categories.Where(x => x.Id == itemFilterPaginationRequest.CategoryId);
            }
            var pagination = categories.SelectMany(x => x.Items)
                .Select(x => _mapper.Map<ItemResponse>(x))
                .ToList()
                .WithPagination(itemFilterPaginationRequest);
            return pagination;
        }
        public void UpdateItem(Guid id, ItemRequest itemRequest)
        {
            var item = _categoryService.Categories
                 .SelectMany(x => x.Items)
                 .SingleOrDefault(x => x.Id == id);
            _ = item ?? throw new NotFoundException(ExceptionMessages.ItemNotFound);
            if (item.CategoryId != itemRequest.CategoryId)
            {
                var newCategory = _categoryService.Categories.SingleOrDefault(x => x.Id == itemRequest.CategoryId);
                _ = newCategory ?? throw new NotFoundException(ExceptionMessages.CategoryNotFound);
                var oldCategory = _categoryService.Categories.Single(x => x.Id == item.CategoryId);
                oldCategory.Items.Remove(item);
                newCategory.Items.Add(item);
            }
            _mapper.Map(itemRequest, item);
        }
    }
}
