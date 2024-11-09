using System.Data;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Data.InMemoryContext;
using Backend.Infrastructure.Repositories.Bases;

namespace Backend.Infrastructure.Repositories.Concretes;

public class VoteRepository(InMemoryDbContext context) : BaseRepositoryInMemoryContext<Vote>(context)
{
    public override Task<Vote> AddAsync(Vote entity)
    {
        var existingVote = DbSet.FindAsync(entity.Id).Result;
        if (existingVote != null)
            throw new DuplicateNameException();
        return base.AddAsync(entity);
    }
}