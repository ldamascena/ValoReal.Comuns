using System;

namespace ValoReal.FGTS.Application.DTOs.Emprestimos;

public class SolicitaEmpDTO
{
    public int IdPessoa { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Ativo { get; set; } = true;
    public int IdEtapa { get; set; }
    public int IdStatus { get; set; }
    public int? IdBanco { get; set; }
    public double? ValorBruto { get; set; }
    public double? ValorLiquido { get; set; }
    public double? ValorParcela { get; set; }
    public int? ValorPrazo { get; set; }
}
