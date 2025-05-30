using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.Services;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.UoW;

namespace Montanelli.Application.Services;

public class PessoaService : ServiceBase<Pessoa>, IPessoaService
{
    private readonly IPessoaRepository _pessoaRepository;


    public PessoaService(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork, ILogger<PessoaService> logger)
    : base(pessoaRepository, unitOfWork)
    {
        _pessoaRepository = pessoaRepository;
    }

    public override async Task<Result<Pessoa>> GetByIdAsync(int id)
    {
        var entity = await _pessoaRepository.GetByIdAsync(id);
        return entity is null ? Result<Pessoa>.NotFound($"{_entityName} não encontrada.") : Result<Pessoa>.Ok(entity);
    }
}
