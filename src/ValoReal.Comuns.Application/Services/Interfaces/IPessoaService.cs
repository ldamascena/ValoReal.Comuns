using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Entities;


namespace Montanelli.Application.Services.Interfaces;

public interface IPessoaService : IServiceBase<Pessoa>
{
    Task<Result<Pessoa>> GetByIdAsync(int id);
}
