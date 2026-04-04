using VagaBond.Backend.Models;

public interface IDestinationServices
{
    Task<IEnumerable<Destination>> GetAllAsync();
    Task<Destination> GetByIdAsync(int id);
    Task<Destination> AddAsync(Destination destination);
    Task<Destination> UpdateAsync(int id, Destination destination);
    Task DeleteAsync(int id);
}