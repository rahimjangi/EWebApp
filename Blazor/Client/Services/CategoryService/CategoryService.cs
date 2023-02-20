using Blazor.Shared;
using System.Net.Http.Json;

namespace Blazor.Client.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;
    public List<Category> Categories { get; set; } = new List<Category>();

    public CategoryService(HttpClient http)
    {
        _http = http;
    }


    public async Task GetCategories()
    {
        ServiceResponse<List<Category>>? response=await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("/api/category");
        if (response!=null && response.Data!=null)
        {
            Categories = response.Data;
        }
    }

    public async Task<ServiceResponse<Category>> GetCategory(int categoryId)
    {
        ServiceResponse<Category>? result= await _http.GetFromJsonAsync<ServiceResponse<Category>>($"/api/category/{categoryId}");
        if (result!=null)
        {
            return result;
        }
        else
        {
            return result?? new ServiceResponse<Category>();
        }
    }
}
