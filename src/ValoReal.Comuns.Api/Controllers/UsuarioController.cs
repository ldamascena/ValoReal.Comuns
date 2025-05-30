using Microsoft.AspNetCore.Mvc;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Api.Controllers;
using ValoReal.Comuns.Api.Controllers.Common;
using ValoReal.Comuns.Application.DTOs.Usuarios;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : EntityReadController<Usuario>
{
    private readonly IUsuarioService _Usuarioervice;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(
        IServiceBase<Usuario> service,
        IUsuarioService Usuarioervice,
        ILogger<UsuarioController> logger)
        : base(service)
    {
        _Usuarioervice = Usuarioervice;
        _logger = logger;
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginRegisterDTO loginUsuario)
    {
        var result = await _Usuarioervice.Login(loginUsuario);
        return FromResult(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UsuarioLoginRegisterDTO registerUsuarioDTO)
    {
        var result = await _Usuarioervice.Register(registerUsuarioDTO);
        return FromResult(result);
    }
}