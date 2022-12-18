using CatalogService.API.Models;

namespace CatalogService.API.Interfaces
{
    public interface ICategoryService
    {
        public List<Category> Categories { get; set; }
        List<CategoryResponse> GetCategories();
        CategoryResponse GetCategory(Guid id);
        CategoryResponse AddCategory(CategoryRequest categoryRequest);
        void UpdateCategory(Guid id, CategoryRequest categoryRequest);
        void DeleteCategory(Guid id);
    }
}
