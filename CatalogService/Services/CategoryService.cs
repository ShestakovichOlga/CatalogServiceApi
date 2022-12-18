using AutoMapper;
using CatalogService.API.Exceptions;
using CatalogService.API.Models;
using CatalogService.API.Interfaces;

namespace CatalogService.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;

        public List<Category> Categories { get; set; }
        public CategoryService(IMapper mapper)
        {
            Categories = new List<Category>();
            InitialCategories();
            _mapper = mapper;
        }
       
        public CategoryResponse AddCategory(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            Categories.Add(category);
            return _mapper.Map<CategoryResponse>(category);
        }
        public void DeleteCategory(Guid id)
        {
            var category = Categories.SingleOrDefault(x => x.Id == id);
            _ = category ?? throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            Categories.Remove(category);
        }
        public List<CategoryResponse> GetCategories()
        {
            return Categories.Select(x => _mapper.Map<CategoryResponse>(x)).ToList();
        }
        public CategoryResponse GetCategory(Guid id)
        {
            var categoryResponse = Categories.Select(x => _mapper.Map<CategoryResponse>(x)).SingleOrDefault(x => x.Id == id);
            _ = categoryResponse ?? throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            return categoryResponse;
        }
        public void UpdateCategory(Guid id, CategoryRequest categoryRequest)
        {
            var category = Categories.SingleOrDefault(x => x.Id == id);
            _ = category ?? throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            _mapper.Map(categoryRequest, category);
        }

        private void InitialCategories()
        {
            for (int j = 1; j <= 10; j++)
            {
                var category = new Category() { Name = $"Category {j}" };

                for (int i = 1; i <= 20; i++)
                {
                    category.Items.Add(new Item()
                    {
                        Name = $"Item {j}.{i}",
                        CategoryId = category.Id
                    });
                }
                Categories.Add(category);
            }
        }
    }
}
