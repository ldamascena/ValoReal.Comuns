using System;
using System.Security;

namespace ValoReal.FGTS.Application.DTOs.Emprestimos;

public class AcompanhamentoDTO
{
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Rg { get; set; }
    public string? NomeMae { get; set; }
    public string? Email { get; set; }
    public string? Celular { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Uf { get; set; }
    public List<DadosBancariosDTO>? DadosBancarios { get; set; } = new List<DadosBancariosDTO>();
}

public class DadosBancariosDTO
{
    public string? Agencia { get; set; }
    public string? Conta { get; set; }
    public string? Digito { get; set; }
    public BancoDTO? Banco { get; set; }
}

public class BancoDTO
{
    public int? Id { get; set; }
    public string? Codigo { get; set; }
    public string? Descricao { get; set; }
    public string? Ativo { get; set; }
    public int? Ordem { get; set; }
}
