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

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result =
            await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
        return result;
    }

    public async Task GetProducts()
    {
        var reresult 
            = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("/api/Product");
        if (reresult!=null && reresult.Data!=null)
        {
            Products = reresult.Data;
        }
    }
}
