using System.Linq.Expressions;
using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.UoW;
using ValoReal.Comuns.Interfaces.Repositorios;

namespace ValoReal.Comuns.Application.Services;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    protected readonly IRepositoryBase<T> _repository;
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly string _entityName;

    public ServiceBase(IRepositoryBase<T> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _entityName = typeof(T).Name;
    }

    public virtual async Task<Result<T?>> GetById(int id)
    {
        var entity = await _repository.GetById(id);
        return entity is null ? Result<T?>.NotFound($"{_entityName} não encontrada.") : Result<T?>.Ok(entity);
    }

    public virtual async Task<Result<T?>> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? Result<T?>.NotFound($"{_entityName} não encontrada.") : Result<T?>.Ok(entity);
    }

    public virtual async Task<Result<IEnumerable<T>>> GetAll()
    {
        var entities = await _repository.GetAll();
        return Result<IEnumerable<T>>.Ok(entities);
    }

    public virtual async Task<Result<IEnumerable<T>>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return Result<IEnumerable<T>>.Ok(entities);
    }

    public virtual Result<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        var result = _repository.Find(predicate);
        return Result<IEnumerable<T>>.Ok(result);
    }

    public virtual Result<string> Add(T entidade)
    {
        _repository.Add(entidade);
        return Result<string>.Created($"{_entityName} adicionada com sucesso.");
    }

    public virtual async Task<Result<T>> AddAsync(T entidade)
    {
        var result = await _repository.AddAsync(entidade);
        return Result<T>.Created(result);
    }

    public virtual Result<string> Update(T entidade)
    {
        _repository.Update(entidade);
        return Result<string>.Ok($"{_entityName} atualizada com sucesso.");
    }

    public virtual async Task<Result<T>> UpdateAsync(T entidade)
    {
        var result = await _repository.UpdateAsync(entidade);
        return Result<T>.Ok(result);
    }

    public virtual Result<string> Delete(T entidade)
    {
        _repository.Delete(entidade);
        return Result<string>.Ok($"{_entityName} removida com sucesso.");
    }

    public void Dispose()
    {
        _repository.Dispose();
    }
}
