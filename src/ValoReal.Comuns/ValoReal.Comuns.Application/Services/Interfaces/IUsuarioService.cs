using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.DTOs.Usuarios;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Entities;


namespace Montanelli.Application.Services.Interfaces;

public interface IUsuarioService : IServiceBase<Usuario>
{
    Task<Result<Usuario>> GetById(int id);
    Task<Result<Usuario>> GetByIdAsync(int id);
    Task<Result<int>> Login(UsuarioLoginRegisterDTO loginUsuario);
    Task<Result<int>> Register(UsuarioLoginRegisterDTO registerUsuarioDTO);
}
