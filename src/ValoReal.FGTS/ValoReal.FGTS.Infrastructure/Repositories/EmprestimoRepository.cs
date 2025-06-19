using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValoReal.FGTS.Domain.Interfaces.Repositories;

namespace ValoReal.FGTS.Infrastructure.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly FgtsDbContext _db;
    public EmprestimoRepository(FgtsDbContext db)
    {
        this._db = db;
    }

    public async Task<Emprestimo?> GetByIdAsync(int id)
    {
        return await _db.Emprestimos.FindAsync(id);
    }

    public async Task<Emprestimo?> GetIdPessoaAsync(int idPessoa)
    {
        return await _db.Emprestimos
            .Where(c => c.IdPessoa == idPessoa && c.Ativo)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Emprestimo emprestimo)
    {
        await _db.Emprestimos.AddAsync(emprestimo);
    }
}
