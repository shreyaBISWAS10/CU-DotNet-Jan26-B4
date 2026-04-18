using Microsoft.EntityFrameworkCore;

using NorthWindCatalog.Services.Data;
using NorthWindCatalog.Services.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly NorthwindContext _context;

    public CategoryRepository(NorthwindContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
}