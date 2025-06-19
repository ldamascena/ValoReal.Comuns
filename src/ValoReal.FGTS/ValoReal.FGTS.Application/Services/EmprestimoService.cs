using ValoReal.FGTS.Application.Common;
using ValoReal.FGTS.Application.DTOs.Emprestimos;
using ValoReal.FGTS.Application.Extensions;
using ValoReal.FGTS.Application.Services.Interfaces;
using ValoReal.FGTS.Application.Services.Interfaces.ExternalServices;
using ValoReal.FGTS.Domain.Interfaces.Repositories;
using ValoReal.FGTS.Domain.UoW;

namespace ValoReal.FGTS.Application.Services;

public class EmprestimoService : IEmprestimoService
{
    private readonly IEmprestimoRepository _emprestimoRepository;
    private readonly IComunsApiService _comunsApiService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly string _entityName = nameof(Emprestimo);


    public EmprestimoService(IEmprestimoRepository emprestimoRepository, IComunsApiService comunsApiService, IUnitOfWork unitOfWork)
    {
        _emprestimoRepository = emprestimoRepository;
        _comunsApiService = comunsApiService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Emprestimo?>> GetByIdAsync(int id)
    {
        var entity = await _emprestimoRepository.GetByIdAsync(id);
        return entity is null ? Result<Emprestimo?>.NotFound($"{_entityName} não encontrada.") : Result<Emprestimo?>.Ok(entity);
    }

    public async Task<Result<bool?>> GetPropostaAtiva(int idPessoa)
    {
        var entity = await _emprestimoRepository.GetIdPessoaAsync(idPessoa);

        return entity is null ? Result<bool?>.NotFound($"proposta não encontrada.") : Result<bool?>.Ok(entity.Ativo);
    }
    
    public async Task<Result<AcompanhamentoDTO?>> GetDadosProposta(int idPessoa)
    {
        var entityEmprestimo = await _emprestimoRepository.GetIdPessoaAsync(idPessoa);

        if (entityEmprestimo is not null && entityEmprestimo.Ativo)
        {
            var entityPessoa = await _comunsApiService.GetPessoaByIdAsync(idPessoa);
            AcompanhamentoDTO entityAcompanhamento = new AcompanhamentoDTO
            {
                Nome = entityPessoa?.Nome,
                Cpf = entityPessoa?.Cpf,
                DataNascimento = entityPessoa?.DataNascimento,
                Rg = entityPessoa?.NumeroRg,
                NomeMae = entityPessoa?.NomeMae,
                Email = entityPessoa?.Email,
                Celular = entityPessoa?.Whatsapp,
                Cep = entityPessoa?.Cep,
                Logradouro = entityPessoa?.Endereco,
                Numero = entityPessoa?.Numero,
                Complemento = entityPessoa?.Complemento,
                Bairro = entityPessoa?.Bairro,
                Cidade = entityPessoa?.CidadeNaturalidade,
                Uf = entityPessoa?.UfNaturalidade,
                DadosBancarios = entityPessoa?.DadosBancarios?.Select(db => new DadosBancariosDTO
                {
                    Agencia = db.Agencia,
                    Conta = db.Conta,
                    Digito = db.Digito.ToString(),
                    Banco = new BancoDTO
                    {
                        Id = db.IdBanco,
                        Codigo = db.Banco?.Codigo,
                        Descricao = db.Banco?.Descricao,
                        Ativo = db.Banco?.Ativo,
                        Ordem = db.Banco?.Ordem
                    }
                }).ToList()
            };
            return Result<AcompanhamentoDTO?>.Ok(entityAcompanhamento);
        }

        return Result<AcompanhamentoDTO?>.NotFound($"{_entityName} não encontrada.");
    }
    

    public async Task<Result<Emprestimo>> AddAsync(SolicitaEmpDTO solicitaEmpDTO)
    {

        Emprestimo emprestimo = new Emprestimo();
        emprestimo.InsertFromDTO(solicitaEmpDTO);
        await _emprestimoRepository.AddAsync(emprestimo);
        var resultCommit = await _unitOfWork.CommitAsync();

        return resultCommit > 0 ? Result<Emprestimo>.Created(emprestimo) : Result<Emprestimo>.Fail("Não foi possível adicionar o empréstimo.");
    }
}
