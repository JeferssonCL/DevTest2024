using Backend.Domain.Bases;
using Backend.Infrastructure.Data.InMemoryContext;
using Backend.Infrastructure.Repositories.Interfaces;

namespace Backend.Infrastructure.Repositories.Bases;

public abstract class BaseRepositoryInMemoryContext<T>(InMemoryDbContext context) : IRepository<T> where T : BaseEntity
{
    protected InMemoryDbSet<T> DbSet = context.Set<T>();
    
    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        var entityToGet = await DbSet.FindAsync(id);
        return entityToGet;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        var response = await GetByIdAsync(entity.Id) == null;
        if (response)
            throw new KeyNotFoundException();
        entity.UpdatedAt = DateTime.UtcNow;
        await DbSet.UpdateAsync(entity);
        return entity;
    }

    public virtual async Task<bool> DeleteByIdAsync(T entity)
    {
        var response = await GetByIdAsync(entity.Id) == null;
        if (response)
            throw new KeyNotFoundException();
        entity.DeletedAt = DateTime.UtcNow;
        entity.IsActive = false;
        return true;
    }

    public virtual Task<IEnumerable<T>> GetAll()
    {
        return Task.FromResult<IEnumerable<T>>(DbSet.GetAllAsync().Result.Where(e => e.IsActive).ToList());
    }
}