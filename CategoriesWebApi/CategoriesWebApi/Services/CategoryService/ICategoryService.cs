using CategoriesWebApi.Models;

namespace CategoriesWebApi.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Get();
        List<Category> GetJsonTree();
    }
}
