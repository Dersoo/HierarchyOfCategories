namespace CategoriesWebApi.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = String.Empty;
        public int? ParentCategoryId { get; set; }
        public List<Category> ChildCategories { get; set; } = new List<Category>();
    }
}
