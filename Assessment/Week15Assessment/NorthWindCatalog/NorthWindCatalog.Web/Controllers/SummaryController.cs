using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using NorthWindCatalog.Web.DTOS;
public class SummaryController : Controller
{
    private readonly HttpClient _client;

    public SummaryController(IHttpClientFactory factory)
    {
        _client = factory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> Index()
    {
        var summary = await _client.GetFromJsonAsync<List<CategorySummaryDto>>
            ("api/products/summary");

        return View(summary);
    }
}