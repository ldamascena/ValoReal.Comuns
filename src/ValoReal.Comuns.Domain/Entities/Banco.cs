using System;
using System.Text.Json.Serialization;

namespace ValoReal.Comuns.Domain.Entities;

public class Banco
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public string Ativo { get; set; }
    public int Ordem { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public virtual ICollection<Pessoa> Pessoas { get; set; } = new List<Pessoa>();

    [JsonIgnore]
    public virtual ICollection<DadosBancario> DadosBancarios { get; set; } = new List<DadosBancario>();
}
