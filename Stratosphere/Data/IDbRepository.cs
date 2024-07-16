namespace Stratosphere.Data;

public interface IDbRepository<T> where T : class
{
    Task<T> GetByGuid(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task<int> Create(T entity);
    Task<int> Update(T entity);
    Task<int> Delete(T entity);
}
