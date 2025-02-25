using System.Linq.Expressions;
using E_Attend.Entities.Models;

namespace E_Attend.Entities.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? IncludeWord = null);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null, string? IncludeWord = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
    }
}
