using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.Repositories;

namespace ValoReal.Comuns.Infrastructure.Repositories;

public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
{
    public PessoaRepository(ComunsDbContext db) : base(db) { }

    public override async Task<Pessoa?> GetByIdAsync(int id)
    {
        return await Db.Pessoas
            .Include(c => c.Banco)
            .Include(c => c.DadosBancarios).ThenInclude(db => db.Banco)
            .Include(c => c.Referencias)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
