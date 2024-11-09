using Backend.Domain.Bases;

namespace Backend.Infrastructure.Data.InMemoryContext;

public class InMemoryDbContext
{
    private readonly Dictionary<Type, object> _context = new();

    public InMemoryDbSet<T> Set<T>() where T : BaseEntity
    {
        var type = typeof(T);

        if (_context.TryGetValue(type, out var set)) 
            return (InMemoryDbSet<T>)set;

        set = new InMemoryDbSet<T>();
        _context[type] = set;
        return (InMemoryDbSet<T>)set;
    }
}