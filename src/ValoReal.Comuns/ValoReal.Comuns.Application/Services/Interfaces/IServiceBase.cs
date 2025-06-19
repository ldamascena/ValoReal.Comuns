using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.UoW;

namespace ValoReal.Comuns.Application.Services.Interfaces;

public interface IServiceBase<T> where T : class
{
    Task<Result<T?>> GetById(int id);
    Task<Result<T?>> GetByIdAsync(int id);
    Task<Result<IEnumerable<T>>> GetAll();
    Task<Result<IEnumerable<T>>> GetAllAsync();
    Result<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    Result<string> Add(T entidade);
    Task<Result<T>> AddAsync(T entidade);
    Result<string> Update(T entidade);
    Task<Result<T>> UpdateAsync(T entidade);
    Result<string> Delete(T entidade);
    void Dispose();
}
