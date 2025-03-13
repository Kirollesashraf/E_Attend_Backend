using System.Linq.Expressions;
using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Generic;

public class GenericService<T> : IGenericService<T> where T : class {
    
    private readonly IUnitOfWork unitOfWork;

    public GenericService(IUnitOfWork _unitOfWork)
        => unitOfWork = _unitOfWork;
    
    public Task<T> GetByIdAsync(int id) {
        
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null) {
        throw new NotImplementedException();
    }

    public Task<T> CreateAsync() {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id) {
        throw new NotImplementedException();
    }
}