using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWindCatalog.Services.DTOs;
using NorthWindCatalog.Services.Repositories;
namespace NorthWindCatalog.Services.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoriesApiController(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine("Reached here");
            var categories = await _repo.GetAllAsync();
          
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
       

    }

}
