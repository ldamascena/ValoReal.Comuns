using System;

namespace ValoReal.FGTS.Domain.Interfaces.Repositories;

public interface IEmprestimoRepository
{
    Task<Emprestimo?> GetByIdAsync(int id);
    Task<Emprestimo?> GetIdPessoaAsync(int idPessoa);
    Task AddAsync(Emprestimo emprestimo);
}
