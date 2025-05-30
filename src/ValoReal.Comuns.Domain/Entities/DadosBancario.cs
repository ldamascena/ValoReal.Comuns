using System;

namespace ValoReal.Comuns.Domain.Entities;

public class DadosBancario
{
    public int Id { get; set; }
    public int IdPessoa { get; set; }
    public int IdBanco { get; set; }
    public string TipoConta { get; set; }
    public string Agencia { get; set; }
    public string Conta { get; set; }
    public Int64? Digito { get; set; }
    public Int64? OpecacaoCaixa { get; set; }
    public string Ativo { get; set; } = "1";
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public virtual Pessoa Pessoa { get; set; }
    public virtual Banco Banco { get; set; }
}
