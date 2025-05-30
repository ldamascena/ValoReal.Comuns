using ValoReal.Comuns.Domain.Interfaces.Repositories;

namespace ValoReal.Comuns.Domain.UoW;

public interface IUnitOfWork : IDisposable
{
    IUsuarioRepository Usuarios { get; }
    IPessoaRepository Pessoas { get; }
    Task<int> CommitAsync();
}
