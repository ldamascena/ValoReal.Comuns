using System;
using System.Threading.Tasks;
using ValoReal.FGTS.Domain.Interfaces.Repositories;
using ValoReal.FGTS.Domain.UoW;
using ValoReal.FGTS.Infrastructure.Repositories;

namespace ValoReal.FGTS.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly FgtsDbContext _context;
    private IEmprestimoRepository _emprestimoRepository;

    public UnitOfWork(FgtsDbContext context)
    {
        _context = context;
    }

    public IEmprestimoRepository Emprestimos => _emprestimoRepository ??= new EmprestimoRepository(_context);    

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
