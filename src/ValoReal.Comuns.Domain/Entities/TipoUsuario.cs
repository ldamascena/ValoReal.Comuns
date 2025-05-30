using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValoReal.Comuns.Domain.Entities
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
