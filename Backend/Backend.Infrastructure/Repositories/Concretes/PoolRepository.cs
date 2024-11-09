using Backend.Domain.Concretes;
using Backend.Infrastructure.Data.InMemoryContext;
using Backend.Infrastructure.Repositories.Bases;

namespace Backend.Infrastructure.Repositories.Concretes;

public class PoolRepository(InMemoryDbContext context) : BaseRepositoryInMemoryContext<Pool>(context);