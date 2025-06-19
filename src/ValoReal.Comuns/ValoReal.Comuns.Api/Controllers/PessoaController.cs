using Microsoft.AspNetCore.Mvc;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Api.Controllers;
using ValoReal.Comuns.Api.Controllers.Common;
using ValoReal.Comuns.Application.DTOs.Pessoas;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : BaseController
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<PessoaController> _logger;

    public PessoaController(
        IPessoaService pessoaService,
        ILogger<PessoaController> logger)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _pessoaService.GetByIdAsync(id);
        return FromResult(result);
    }

    [HttpPost("upsert-fgts")]
    public async Task<IActionResult> UpsertFgtsPessoaAsync(FgtsPessoaDTO fgtsPessoa)
    {
        var result = await _pessoaService.UpsertFgtsPessoaAsync(fgtsPessoa);
        return FromResult(result);
    }
}