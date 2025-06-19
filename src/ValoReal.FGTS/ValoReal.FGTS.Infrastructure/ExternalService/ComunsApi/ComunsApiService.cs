using System;
using System.Net.Http;
using System.Net.Http.Json;
using ValoReal.FGTS.Application.DTOs.External;
using ValoReal.FGTS.Application.Services.Interfaces.ExternalServices;

namespace ValoReal.Comuns.Infrastructure.ExternalService.ComunsApi;

public class ComunsApiService : IComunsApiService
{
    private readonly HttpClient _httpClient;

    public ComunsApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ComunsApi");
    }

    public async Task<PessoaApiDTO?> GetPessoaByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/pessoa/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<PessoaApiDTO>();
    }
}