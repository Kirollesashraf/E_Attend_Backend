using System.Linq.Expressions;

namespace E_Attend.Service.Generic;

public interface IGenericService <T> where T : class {
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> CreateAsync();
    Task UpdateAsync(int id);
    Task DeleteAsync(int id);
}