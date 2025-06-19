using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.Repositories;

namespace ValoReal.Comuns.Infrastructure.Repositories;

public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ComunsDbContext db) : base(db) { }

    public async Task<(IEnumerable<Usuario> Itens, int TotalRegistros)> GetAllPaginated(
        int page,
        int pageSize,
        string? cpf = null)
    {
        var query = Db.Usuarios.AsQueryable();
        if (!string.IsNullOrWhiteSpace(cpf))
        {
            query = query.Where(c => c.Cpf.Contains(cpf));
        }

        var totalRegistros = await query.CountAsync();
        var Usuarios = await query
            .OrderBy(c => c.Cpf)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

        return (Usuarios, totalRegistros);
    }

    public override async Task<Usuario?> GetByIdAsync(int id)
    {
        return await Db.Usuarios
            .Include(c => c.TipoUsuario)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await Db.Usuarios
            .Include(c => c.TipoUsuario)
            .OrderBy(c => c.Cpf)
            .ToListAsync();
    }

    public async Task<Usuario?> GetByCpf(string cpf)
    {
        return await Db.Usuarios
            .Where(c => c.Cpf == cpf)
            .FirstOrDefaultAsync();
    }
}
