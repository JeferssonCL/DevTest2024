using System.Data;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Data.InMemoryContext;
using Backend.Infrastructure.Repositories.Bases;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories.Concretes;

public class VoteRepository(DbContext context) : BaseRepositoryDbContext<Vote>(context);