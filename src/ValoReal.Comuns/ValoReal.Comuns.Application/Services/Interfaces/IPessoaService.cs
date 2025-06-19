using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.DTOs.Pessoas;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Entities;


namespace Montanelli.Application.Services.Interfaces;

public interface IPessoaService : IServiceBase<Pessoa>
{
    Task<Result<Pessoa>> GetByCPfAsync(string cpf);
    Task<Result<Pessoa>> UpsertFgtsPessoaAsync(FgtsPessoaDTO FgtsPessoaDTO);
    Task<Result<Pessoa?>> GetByIdAsync(int id);
}
