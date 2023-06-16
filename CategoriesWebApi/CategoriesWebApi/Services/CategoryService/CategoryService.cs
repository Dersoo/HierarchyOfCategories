using CategoriesWebApi.Models;

namespace CategoriesWebApi.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly List<Category> _categories;

        public CategoryService()
        {
            _categories = new List<Category>()
            {
                new Category { CategoryId = 1, CategoryName = "Category-1" },
                new Category { CategoryId = 4, CategoryName = "Category-1-1", ParentCategoryId = 1 },
                new Category { CategoryId = 5, CategoryName = "Category-1-2", ParentCategoryId = 1 },
                new Category { CategoryId = 8, CategoryName = "Category-1-2-1", ParentCategoryId = 5 },
                new Category { CategoryId = 9, CategoryName = "Category-1-2-2", ParentCategoryId = 5 },
                new Category { CategoryId = 2, CategoryName = "Category-2" },
                new Category { CategoryId = 3, CategoryName = "Category-3" },
                new Category { CategoryId = 6, CategoryName = "Category-3-1", ParentCategoryId = 3 },
                new Category { CategoryId = 7, CategoryName = "Category-3-2", ParentCategoryId = 3 },
                new Category { CategoryId = 10, CategoryName = "Category-3-2-1", ParentCategoryId = 7 },
                new Category { CategoryId = 11, CategoryName = "Category-3-2-1-1", ParentCategoryId = 10 },
                new Category { CategoryId = 12, CategoryName = "Category-3-2-1-1-1", ParentCategoryId = 11 }
            };
        }

        public List<Category> Get()
        {
            return _categories;
        }

        public List<Category> GetJsonTree()
        {
            List<Category> categories = new List<Category>(_categories);
            List<Category> categoriesToDelete = new List<Category>();

            foreach (Category category in categories.ToList())
            {
                if (category.ParentCategoryId != null)
                {
                    var index = categories.FindIndex(c => c.CategoryId == category.ParentCategoryId);

                    if (index != -1)
                    {
                        categories[index]?.ChildCategories.Add(category);
                        categoriesToDelete.Add(category);
                    }
                }
            }

            return categories.Except(categoriesToDelete).ToList();
        }
    }
}
