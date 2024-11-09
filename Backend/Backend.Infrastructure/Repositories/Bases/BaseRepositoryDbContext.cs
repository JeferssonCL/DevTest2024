using Backend.Domain.Bases;
using Backend.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Bases;

public class BaseRepositoryDbContext<T>(DbContext dbContext) : IRepository<T> where T : BaseEntity
{
    protected DbContext Context = dbContext;
    protected DbSet<T> DbSet => Context.Set<T>();
    
    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity == null) throw new KeyNotFoundException();
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        var response = await GetByIdAsync(entity.Id) == null;
        if (response) throw new KeyNotFoundException();
        
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
        return entity;    }

    public virtual async Task<bool> DeleteByIdAsync(T entity)
    {
        var response = await GetByIdAsync(entity.Id) == null;
        if (response) throw new KeyNotFoundException();
        
        entity.DeletedAt = DateTime.UtcNow;
        entity.IsActive = false;
        return true;
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await DbSet.Where(e => e.IsActive == true).ToListAsync();
    }
}