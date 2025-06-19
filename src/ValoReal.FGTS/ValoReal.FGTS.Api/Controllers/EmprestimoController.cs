using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValoReal.Comuns.Api.Controllers;
using ValoReal.FGTS.Application.DTOs.Emprestimos;
using ValoReal.FGTS.Application.Services.Interfaces;

namespace ValoReal.FGTS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : BaseController
    {
        private readonly IEmprestimoService _emprestimoService;
        private readonly ILogger<EmprestimoController> _logger;

        public EmprestimoController(
            IEmprestimoService emprestimoService,
            ILogger<EmprestimoController> logger)
        {
            _emprestimoService = emprestimoService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _emprestimoService.GetByIdAsync(id);
            return FromResult(result);
        }

        [HttpGet("proposta-ativa/{idPessoa}")]
        public async Task<IActionResult> GetPropostaAtiva(int idPessoa)
        {
            var result = await _emprestimoService.GetPropostaAtiva(idPessoa);
            return FromResult(result);
        }

        [HttpGet("dados-proposta/{idPessoa}")]
        public async Task<IActionResult> GetDadosProposta(int idPessoa)
        {
            var result = await _emprestimoService.GetDadosProposta(idPessoa);
            return FromResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SolicitaEmpDTO solicitaEmpDTO)
        {
            var result = await _emprestimoService.AddAsync(solicitaEmpDTO);
            return FromResult(result);
        }
    }
}
