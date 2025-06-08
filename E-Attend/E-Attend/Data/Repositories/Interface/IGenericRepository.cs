using System.Linq.Expressions;

namespace E_Attend.Data.Repositories.Interface;

public interface IGenericRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes);

    public Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes);

    void AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}