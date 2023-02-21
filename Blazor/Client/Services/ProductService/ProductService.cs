using Blazor.Shared;
using System.Net.Http.Json;

namespace Blazor.Client.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }
    public List<Product> Products { get; set; }= new List<Product>();

    public event Action ProductsChanged;

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result =
            await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        return result;
    }

    public async Task GetProducts(string? categoryUrl=null)
    {
        var reresult =categoryUrl==null?
            await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("/api/Product")
            : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"/api/Product/category/{categoryUrl}");
        if (reresult!=null && reresult.Data!=null)
        {
            Products = reresult.Data;
        }
        ProductsChanged.Invoke();
    }
}
