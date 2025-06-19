using System;
using ValoReal.Comuns.Application.DTOs.Pessoas;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Application.Extensions;

public static class PessoaExtensions
{
    public static void UpsertFromDTO(this Pessoa pessoa, FgtsPessoaDTO dto)
    {
        pessoa.Cpf = dto.Cpf;
        pessoa.Nome = dto.Nome;
        pessoa.DataNascimento = dto.DataNascimento;
        pessoa.Email = dto.Email;
        pessoa.TelefoneCelular = dto.TelefoneCelular;
        pessoa.UpdatedAt = dto.UpdatedAt ?? DateTime.UtcNow;
        pessoa.Cep = dto.Cep;
        pessoa.Endereco = dto.Endereco;
        pessoa.Numero = dto.Numero;
        pessoa.Complemento = dto.Complemento;
        pessoa.Bairro = dto.Bairro;
        pessoa.IdCidade = dto.IdCidade;
        pessoa.IdUf = dto.IdUf;
        pessoa.NumeroRg = dto.NumeroRg;
        pessoa.NomeMae = dto.NomeMae;
        pessoa.IdTipoPix = dto.IdTipoPix;
        pessoa.ValorChavePix = dto.ValorChavePix;
        pessoa.BancoPix = dto.BancoPix;
        pessoa.IdTipoEstadoCivil = dto.IdTipoEstadoCivil;
        pessoa.Genero = dto.Genero;
    }
}
