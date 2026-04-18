using NorthWindCatalog.Services.Models;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
}
