using System;
using ValoReal.FGTS.Application.DTOs.External;

namespace ValoReal.FGTS.Application.Services.Interfaces.ExternalServices;

public interface IComunsApiService
{
    Task<PessoaApiDTO?> GetPessoaByIdAsync(int id);
}
