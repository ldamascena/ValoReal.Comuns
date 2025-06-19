using System;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Interfaces.Repositorios;

namespace ValoReal.Comuns.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IRepositoryBase<Usuario>
{
    Task<(IEnumerable<Usuario> Itens, int TotalRegistros)> GetAllPaginated(int page, int pageSize, string? cpf = null);
    Task<Usuario?> GetByIdAsync(int id);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario?> GetByCpf(string cpf);
}
