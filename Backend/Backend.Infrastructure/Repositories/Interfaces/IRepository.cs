using Backend.Domain.Bases;

namespace Backend.Infrastructure.Repositories.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    public Task<T> AddAsync(T entity);
    public Task<T?> GetByIdAsync(Guid id);
    public Task<T> UpdateAsync(T entity);
    public Task<bool> DeleteByIdAsync(T entity);
    public Task<IEnumerable<T>> GetAll();
}