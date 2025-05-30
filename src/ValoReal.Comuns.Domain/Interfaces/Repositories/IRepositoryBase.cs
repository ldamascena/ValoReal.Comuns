using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ValoReal.Comuns.Interfaces.Repositorios;

public interface IRepositoryBase<T> where T : class
{
    Task<T?> GetById(int id);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    void Add(T entidade);
    Task<T> AddAsync(T entidade);
    void Update(T entidade);
    Task<T> UpdateAsync(T entidade);
    void Delete(T entidade);
    void Dispose();
}
