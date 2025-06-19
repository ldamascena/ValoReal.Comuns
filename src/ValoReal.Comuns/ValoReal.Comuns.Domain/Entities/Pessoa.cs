using System;
using System.Text.Json.Serialization;

namespace ValoReal.Comuns.Domain.Entities;

public class Pessoa
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Email { get; set; }
    public Int64? TelefoneFixo { get; set; }
    public Int64? TelefoneCelular { get; set; }
    public string? Whatsapp { get; set; } = "0";
    public int? Tpso_Id { get; set; }
    public string? Status { get; set; } = "1"; // 1 - Ativo, 0 - Inativo
    public string? Tipo { get; set; } = "2"; // 1 - Funcionario, 2 - Cliente
    public string? RgFrente { get; set; }
    public string? RgVerso { get; set; }
    public string? Motivo { get; set; }
    public string? Excluido { get; set; } = "0";
    public string? EmailConfirmado { get; set; } = "0"; // 0 - Não confirmado, 1 - Confirmado
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
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
    public string? PrimeiroNome
    {
        get
        {
            return Nome != null ? Nome.Substring(0, Nome.IndexOf(' ')) : null;
        }
    }
    public string? NumeroRg { get; set; }
    public string? NomeMae { get; set; }
    public int? IdTipoPix { get; set; }
    public string? ValorChavePix { get; set; }
    public int? IdTipoEstadoCivil { get; set; }
    public string? Genero { get; set; }
    [JsonIgnore]
    public int? BancoPix { get; set; }
    public string? Uuid { get; set; }
    public string? RgEmissao { get; set; }
    public string? ValorAdicional1 { get; set; }
    public string? ValorAdicional2 { get; set; }
    public string? UfNaturalidade { get; set; }
    public string? CidadeNaturalidade { get; set; }

    // Relacionamento
    // public virtual EstadoCivil EstadoCivil { get; set; }
    // public virtual TipoPix TipoPix { get; set; }
    public virtual Banco? Banco { get; set; }
    public virtual ICollection<DadosBancario> DadosBancarios { get; set; } = new List<DadosBancario>();
    public virtual ICollection<Referencia> Referencias { get; set; } = new List<Referencia>();
    
}
