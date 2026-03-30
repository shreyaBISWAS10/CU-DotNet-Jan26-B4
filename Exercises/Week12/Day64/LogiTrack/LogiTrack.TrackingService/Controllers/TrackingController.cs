using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tracking")]
public class TrackingController : ControllerBase
{
    [HttpGet("gps")]
    [Authorize(Roles = "Manager")]
    public IActionResult GetGpsData()
    {
        return Ok("Sensitive GPS Data: Truck locations...");
    }
}