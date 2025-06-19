using ValoReal.Comuns.Domain.Entities;

public class Emprestimo
{
    public int Id { get; set; }
    public int IdPessoa { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Ativo { get; set; }
    public int IdEtapa { get; set; }
    public int IdStatus { get; set; }
    public int? IdBanco { get; set; }
    public double? ValorBruto { get; set; }
    public double? ValorLiquido { get; set; }
    public double? ValorParcela { get; set; }
    public int? ValorPrazo { get; set; }
    public string? Tabela { get; set; }
    
    // public virtual Etapa Etapa { get; set; }

    // public virtual Status Status { get; set; }

}