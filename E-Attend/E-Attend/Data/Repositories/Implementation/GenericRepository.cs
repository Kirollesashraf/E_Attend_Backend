using System.Linq.Expressions;
using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace E_Attend.Data.Repositories.Implementation;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T>
    where T : class
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(predicate, includes);
        return await query.ToListAsync();
    }

    public async Task<T?> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes)
    {
        var query = BuildQuery(predicate, includes);
        return await query.FirstOrDefaultAsync();
    }

    private IQueryable<T> BuildQuery(
        Expression<Func<T, bool>>? predicate = null,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return includes.Aggregate(query, (current, include) => current.Include(include));
    }


    public async void AddAsync(T entity) => await _dbSet.AddAsync(entity);


    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Remove(T entity) => _dbSet.Remove(entity);
}