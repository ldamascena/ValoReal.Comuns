using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.DTOs.Pessoas;
using ValoReal.Comuns.Application.Extensions;
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

    public override async Task<Result<Pessoa?>> GetByIdAsync(int id)
    {
        var entity = await _pessoaRepository.GetByIdAsync(id);
        return entity is null ? Result<Pessoa?>.NotFound($"{_entityName} não encontrada.") : Result<Pessoa?>.Ok(entity);
    }

    public async Task<Result<Pessoa>> GetByCPfAsync(string cpf)
    {
        var entity = await _pessoaRepository.GetByCPfAsync(cpf);
        return entity is null ? Result<Pessoa>.NotFound($"{_entityName} não encontrada.") : Result<Pessoa>.Ok(entity);
    }

    public async Task<Result<Pessoa>> UpsertFgtsPessoaAsync(FgtsPessoaDTO FgtsPessoaDTO)
    {
        var pessoa = await _pessoaRepository.GetByCPfAsync(FgtsPessoaDTO.Cpf);

        if (pessoa is null)
        {
            pessoa = new Pessoa();
            pessoa.UpsertFromDTO(FgtsPessoaDTO);
            var addResult = await AddAsync(pessoa);
            await _unitOfWork.CommitAsync();
            return addResult.Success ? Result<Pessoa>.Created(pessoa) : Result<Pessoa>.Fail(addResult.Message);
        }

        pessoa.UpsertFromDTO(FgtsPessoaDTO);
        var result = await UpdateAsync(pessoa);
        await _unitOfWork.CommitAsync();
        return result.Success ? Result<Pessoa>.Ok(pessoa) : Result<Pessoa>.Fail(result.Message);
    }
}
