using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using NorthWindCatalog.Web.DTOS;
public class ProductsController : Controller
{
    private readonly HttpClient _client;

    public ProductsController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> ByCategory(int id)
    {
        var products = await _client.GetFromJsonAsync<List<ProductDto>>
            ($"api/products/by-category/{id}");

        return View(products);
    }
}