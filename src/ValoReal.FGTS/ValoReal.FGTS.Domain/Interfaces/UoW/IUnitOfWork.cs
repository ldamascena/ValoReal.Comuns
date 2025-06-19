using ValoReal.FGTS.Domain.Interfaces.Repositories;

namespace ValoReal.FGTS.Domain.UoW;

public interface IUnitOfWork : IDisposable
{
    IEmprestimoRepository Emprestimos { get; }
    Task<int> CommitAsync();
}
