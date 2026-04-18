using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using NorthWindCatalog.Web.DTOS;

public class CategoriesController : Controller
{
    private readonly HttpClient _client;

    public CategoriesController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> Index()
    {
        var data = await _client.GetFromJsonAsync<List<CategoryDto>>("api/categories");
        return View(data);
    }
}