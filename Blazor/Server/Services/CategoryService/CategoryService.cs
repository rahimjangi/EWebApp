namespace Blazor.Server.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Category>>> GetCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return new ServiceResponse<List<Category>>
            {
                Data=categories
            };
        }

        public async Task<ServiceResponse<Category>> GetCategoryAsync(int categoryId)
        {
            var result = new ServiceResponse<Category>();
            Category? category = await _context.Categories.FirstOrDefaultAsync(c=>c.Id==categoryId);
            if (category == null)
            {
                result.Success = false;
                result.Message = "Sorry, but this category does not exist";
            }
            else
            {
                result.Data = category;
            }
            return result;
        }
    }
}
