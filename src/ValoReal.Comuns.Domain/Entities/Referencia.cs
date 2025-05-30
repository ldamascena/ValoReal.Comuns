using System;

namespace ValoReal.Comuns.Domain.Entities;

public class Referencia
{
    public int Id { get; set; }
    public int? IdPessoa { get; set; }
    public string Nome1 { get; set; }
    public string Nome2 { get; set; }
    public Int64 Telefone1 { get; set; }
    public Int64 Telefone2 { get; set; }
    public string Ativo { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public virtual Pessoa Pessoa { get; set; }
}
