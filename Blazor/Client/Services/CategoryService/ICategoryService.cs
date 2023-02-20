
using Blazor.Shared;

namespace Blazor.Client.Services.CategoryService;

public interface ICategoryService
{
    List<Category> Categories { get; set; }
    Task GetCategories();
    Task<ServiceResponse<Category>> GetCategory(int categoryId);
}
