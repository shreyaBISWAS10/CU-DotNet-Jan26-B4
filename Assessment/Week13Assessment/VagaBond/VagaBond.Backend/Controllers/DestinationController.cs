using Microsoft.AspNetCore.Mvc;
using VagaBond.Backend.Models;

[ApiController]
[Route("api/[controller]")]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationServices _service;

    public DestinationsController(IDestinationServices service)
    {
        _service = service;
    }

   
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var destinations = await _service.GetAllAsync();
        return Ok(destinations);
    }

 
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var destination = await _service.GetByIdAsync(id);
        return Ok(destination);
    }

   
    [HttpPost]
    public async Task<IActionResult> Create(Destination destination)
    {
        var created = await _service.AddAsync(destination);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Destination destination)
    {
        var updated = await _service.UpdateAsync(id, destination);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}