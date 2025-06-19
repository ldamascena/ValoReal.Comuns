using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Application.Common;
using ValoReal.Comuns.Application.DTOs.Usuarios;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.UoW;

namespace ValoReal.Comuns.Application.Services;

public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;


    public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, ILogger<UsuarioService> logger)
    : base(usuarioRepository, unitOfWork)
    {
        _usuarioRepository = usuarioRepository;
    }

    public override async Task<Result<Usuario>> GetById(int id)
    {
        var entity = await _usuarioRepository.GetById(id);
        return entity is null ? Result<Usuario>.NotFound($"{_entityName} não encontrada.") : Result<Usuario>.Ok(entity);
    }

    public override async Task<Result<Usuario>> GetByIdAsync(int id)
    {
        var entity = await _usuarioRepository.GetByIdAsync(id);
        return entity is null ? Result<Usuario>.NotFound($"{_entityName} não encontrada.") : Result<Usuario>.Ok(entity);
    }

    public async Task<Result<int>> Login(UsuarioLoginRegisterDTO loginUsuario)
    {

        var usuario = await _usuarioRepository.GetByCpf(loginUsuario.Cpf);
        if (usuario == null)
            return Result<int>.NotFound("Usuario não encontrado!");

        if (!CompararMD5(loginUsuario.Senha, usuario.Senha))
            return Result<int>.Fail("Usuario ou senha incorretos!");

        return Result<int>.Ok(usuario.Id);
    }

    public async Task<Result<int>> Register(UsuarioLoginRegisterDTO registerUsuarioDTO)
    {
        registerUsuarioDTO.Senha = RetornarMD5(registerUsuarioDTO.Senha);
        await _usuarioRepository.AddAsync(new Usuario
        {
            Senha = registerUsuarioDTO.Senha,
            Cpf = registerUsuarioDTO.Cpf
        });

        var returnCommit = await _unitOfWork.CommitAsync();

        return returnCommit > 0 ? Result<int>.Created(returnCommit) : Result<int>.Fail("Não foi possível registrar o usuário.")
;
    }

    private string RetornarMD5(string Senha)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            return RetornarHash(md5Hash, Senha);
        }
    }
    private string RetornarHash(MD5 md5Hash, string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("X2"));
        }

        return sBuilder.ToString();
    }

    private bool VerificaHash(string input, string hash)
    {
        StringComparer comparar = StringComparer.OrdinalIgnoreCase;

        if (comparar.Compare(input, hash) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CompararMD5(string senhaEntrada, string senhaMD5)
    {
        string senha = RetornarMD5(senhaEntrada);

        if (VerificaHash(senhaMD5, senha))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
