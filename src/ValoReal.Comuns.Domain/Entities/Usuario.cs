using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValoReal.Comuns.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Ativo { get; set; } = "1";
        public string Excluido { get; set; } = "0";
        public string? MotivoExclusao { get; set; }
        public int? PessoaIdQueExcluiu { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public string? AtribuiLead { get; set; }
        public int? TipoUsuarioId { get; set; }

        // Relacionamento
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
