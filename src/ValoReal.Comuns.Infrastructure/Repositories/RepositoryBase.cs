using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ValoReal.Comuns.Infrastructure;
using ValoReal.Comuns.Interfaces.Repositorios;


namespace ValoReal.Comuns.Domain.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly ComunsDbContext Db;
    protected readonly DbSet<T> DbSet;

    public RepositoryBase(ComunsDbContext db)
    {
        Db = db;
        DbSet = db.Set<T>();
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await DbSet.FindAsync(id);
    }
    
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAll()
    {
        return await DbSet.ToListAsync();
    }
    
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return DbSet.AsNoTracking().Where(predicate);
    }

    public virtual void Add(T entidade)
    {
        DbSet.Add(entidade);
    }
    
    public virtual async Task<T> AddAsync(T entidade)
    {
        await DbSet.AddAsync(entidade);
        return entidade;
    }

    public virtual void Update(T entidade)
    {
        DbSet.Update(entidade);
    }
    
    public virtual async Task<T> UpdateAsync(T entidade)
    {
        DbSet.Update(entidade);
        return await Task.FromResult(entidade);
    }

    public virtual void Delete(T entidade)
    {
        DbSet.Remove(entidade);
    }

    public void Dispose()
    {
        Db.Dispose();
        GC.SuppressFinalize(this);
    }
}
