namespace Stratosphere.Data;

public class DbRepository<T> : IDbRepository<T> where T : class
{
    private readonly StratosphereContext _context;

    public DbRepository(StratosphereContext context)
    {
        _context = context;
    }

    public async Task<T> GetByGuid(Guid id)
    {
        return default;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return default;
    }

    public async Task<int> Create(T entity)
    {
        return default;
    }

    public async Task<int> Update(T entity)
    {
        return default;
    }

    public async Task<int> Delete(T entity)
    {
        return default;
    }
}
