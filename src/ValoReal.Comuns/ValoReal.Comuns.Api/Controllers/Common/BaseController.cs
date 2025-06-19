using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ValoReal.Comuns.Application.Common;

namespace ValoReal.Comuns.Api.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult FromResult<T>(Result<T> result)
    {
        if (result == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                error = "Erro interno",
                detalhes = "Resultado nulo"
            });
        }

        object response = result.Success
            ? (object?)result.Data!
            : new { error = result.Message ?? "Erro desconhecido" };

        return StatusCode((int)result.StatusCode, response);
    }
}
