using Backend.Domain.Bases;

namespace Backend.Infrastructure.Data.InMemoryContext;

public class InMemoryDbSet<T> where T : BaseEntity
{
    private readonly Dictionary<Guid, T> _entities = new();

    public Task<T> AddAsync(T entity)
    {
        _entities[entity.Id] = entity;
        return Task.FromResult(entity);
    }
    
    public Task<T?> FindAsync(Guid id)
    {
        var result = _entities.TryGetValue(id, out var entity);
        if (!result)
            throw new KeyNotFoundException();
        return Task.FromResult(entity);
    }
    
    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_entities.Values.AsEnumerable());
    }

    public Task<T> UpdateAsync(T entity)
    {
        var response = _entities.TryGetValue(entity.Id, out _);
        if (!response)
            throw new KeyNotFoundException();
        _entities[entity.Id] = entity;
        return Task.FromResult(entity);
    }
    
    public Task<bool> DeletedById(Guid id)
    {
        return Task.FromResult(_entities.Remove(id));
    }
}