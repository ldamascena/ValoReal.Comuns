using System;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Interfaces.Repositorios;

namespace ValoReal.Comuns.Domain.Interfaces.Repositories;

public interface IPessoaRepository : IRepositoryBase<Pessoa>
{
    Task<Pessoa?> GetByIdAsync(int id);
}
