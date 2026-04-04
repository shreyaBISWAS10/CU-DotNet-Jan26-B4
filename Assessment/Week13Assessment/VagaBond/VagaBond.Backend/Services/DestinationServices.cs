
using VagaBond.Backend.Models;
using VagaBond.Backend.Repository;

public class DestinationServices : IDestinationServices
{
    private readonly IDestinationRepository _repository;

    public DestinationServices(IDestinationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Destination> GetByIdAsync(int id)
    {
        var destination = await _repository.GetByIdAsync(id);

        if (destination == null)
            throw new DestinationNotFoundException($"Destination with ID {id} not found");

        return destination;
    }

    public async Task<Destination> AddAsync(Destination destination)
    {
        await _repository.AddAsync(destination);
        return destination;
    }

    public async Task<Destination> UpdateAsync(int id, Destination destination)
    {
        var existing = await _repository.GetByIdAsync(id);

        if (existing == null)
            throw new DestinationNotFoundException($"Destination with ID {id} not found");

        existing.CityName = destination.CityName;
        existing.Country = destination.Country;
        existing.Description = destination.Description;
        existing.Rating = destination.Rating;
        existing.LastVisited = destination.LastVisited;

        await _repository.UpdateAsync(existing);

        return existing;
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);

        if (existing == null)
            throw new DestinationNotFoundException($"Destination with ID {id} not found");

        await _repository.DeleteAsync(id);
    }
}