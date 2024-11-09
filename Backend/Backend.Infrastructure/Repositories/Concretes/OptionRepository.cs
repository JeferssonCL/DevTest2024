using Backend.Domain.Concretes;
using Backend.Infrastructure.Data.InMemoryContext;
using Backend.Infrastructure.Repositories.Bases;

namespace Backend.Infrastructure.Repositories.Concretes;

public class OptionRepository(InMemoryDbContext context) : BaseRepositoryInMemoryContext<Option>(context);
