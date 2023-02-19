﻿using Blazor.Shared;

namespace Blazor.Client.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get;set; }
    Task GetProducts();
}