using System;
using System.Threading.Tasks;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.UoW;
using ValoReal.Comuns.Infrastructure.Repositories;

namespace ValoReal.Comuns.Infrastructure.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ComunsDbContext _context;
    private IUsuarioRepository _usuarioRepository;
    private IPessoaRepository _pessoaRepository;

    public UnitOfWork(ComunsDbContext context)
    {
        _context = context;
    }
    
    public IUsuarioRepository Usuarios => _usuarioRepository ??= new UsuarioRepository(_context);
    public IPessoaRepository Pessoas => _pessoaRepository ??= new PessoaRepository(_context);
        

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
