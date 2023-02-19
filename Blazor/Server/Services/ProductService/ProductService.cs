namespace Blazor.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            ServiceResponse<Product> response = new ServiceResponse<Product>();
            Product? product= await _context.Products.FirstOrDefaultAsync(p=>p.Id==productId);
            if (product == null)
            {
                response.Success= false;
                response.Message = "Sorry, but this product does not exist!";
            }
            else
            {
                response.Success= true;
                response.Data = product;
            }
            return response;
            
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response =new ServiceResponse<List<Product>>()
            {
                Data= await _context.Products.ToListAsync()
            };
            return response;
        }
    }
}
