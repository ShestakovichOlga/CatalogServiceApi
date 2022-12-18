using AutoMapper;
using CatalogService.API.Models;

namespace CatalogService.API.Services
{
    public class MapperProfileService : Profile
    {
        public MapperProfileService()
        {
            CreateMap<ItemRequest, Item>();
            CreateMap<Item, ItemResponse>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
