using System;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.FGTS.Application.DTOs.External;

public class PessoaApiDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Email { get; set; }
    public Int64? TelefoneFixo { get; set; }
    public Int64? TelefoneCelular { get; set; }
    public string? Whatsapp { get; set; }
    public int? Tpso_Id { get; set; }
    public string? Status { get; set; }
    public string? Tipo { get; set; }
    public string? RgFrente { get; set; }
    public string? RgVerso { get; set; }
    public string? Motivo { get; set; }
    public string? Excluido { get; set; }
    public string? EmailConfirmado { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public int? IdCidade { get; set; }
    public int? IdUf { get; set; }
    public int? CiaeId { get; set; }
    public DateTime? AceiteTermo { get; set; }
    public string? FaturaEnergia { get; set; }
    public bool? Blacklist { get; set; } = false;
    public string? BlacklistMotivo { get; set; }
    public DateTime? DataInclusaoBlacklist { get; set; }
    public string? Selfie { get; set; }
    public string? NumeroRg { get; set; }
    public string? NomeMae { get; set; }
    public int? IdTipoPix { get; set; }
    public string? ValorChavePix { get; set; }
    public int? IdTipoEstadoCivil { get; set; }
    public string? Genero { get; set; }
    public int? BancoPix { get; set; }
    public string? Uuid { get; set; }
    public string? RgEmissao { get; set; }
    public string? ValorAdicional1 { get; set; }
    public string? ValorAdicional2 { get; set; }
    public string? UfNaturalidade { get; set; }
    public string? CidadeNaturalidade { get; set; }
    public List<PessoaApiDadosBancariosDTO>? DadosBancarios { get; set; } = new List<PessoaApiDadosBancariosDTO>();
}

public class PessoaApiDadosBancariosDTO
{
    public int Id { get; set; }
    public int IdBanco { get; set; }
    public string TipoConta { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public Int64? Digito { get; set; }
    public BancoApiBancoDTO? Banco { get; set; }
}

public class BancoApiBancoDTO
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public string Ativo { get; set; }
    public int Ordem { get; set; }
}
