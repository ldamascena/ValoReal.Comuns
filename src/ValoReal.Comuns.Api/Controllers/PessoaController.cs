using Microsoft.AspNetCore.Mvc;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Api.Controllers;
using ValoReal.Comuns.Api.Controllers.Common;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : EntityReadController<Pessoa>
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<PessoaController> _logger;

    public PessoaController(
        IServiceBase<Pessoa> service,
        IPessoaService pessoaService,
        ILogger<PessoaController> logger)
        : base(service)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    [HttpGet("{id:int}")]
    public override async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _pessoaService.GetByIdAsync(id);
        return FromResult(result);
    }
}