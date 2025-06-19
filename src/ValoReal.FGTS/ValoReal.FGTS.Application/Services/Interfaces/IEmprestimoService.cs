using ValoReal.FGTS.Application.Common;
using ValoReal.FGTS.Application.DTOs.Emprestimos;

namespace ValoReal.FGTS.Application.Services.Interfaces;

public interface IEmprestimoService
{
    Task<Result<Emprestimo>> GetByIdAsync(int id);
    Task<Result<bool?>> GetPropostaAtiva(int idPessoa);
    Task<Result<AcompanhamentoDTO?>> GetDadosProposta(int idPessoa);
    Task<Result<Emprestimo>> AddAsync(SolicitaEmpDTO solicitaEmpDTO);
}
