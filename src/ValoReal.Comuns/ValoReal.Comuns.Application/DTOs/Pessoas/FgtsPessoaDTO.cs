using System;

namespace ValoReal.Comuns.Application.DTOs.Pessoas;

public class FgtsPessoaDTO
{
    public string? Cpf { get; set; }
    public string? Nome { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Email { get; set; }
    public Int64? TelefoneCelular { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public int? IdCidade { get; set; }
    public int? IdUf { get; set; }
    public string? NumeroRg { get; set; }
    public string? NomeMae { get; set; }
    public int? IdTipoPix { get; set; }
    public string? ValorChavePix { get; set; }
    public int? BancoPix { get; set; }
    public int? IdTipoEstadoCivil { get; set; }
    public string? Genero { get; set; }
}
