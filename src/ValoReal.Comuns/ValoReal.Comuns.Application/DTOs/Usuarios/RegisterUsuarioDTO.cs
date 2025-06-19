using System;

namespace ValoReal.Comuns.Application.DTOs.Usuarios;

public class RegisterUsuarioDTO
{
    public string Cpf { get; set; } = null!;
    public string Senha { get; set; } = null!;
}
