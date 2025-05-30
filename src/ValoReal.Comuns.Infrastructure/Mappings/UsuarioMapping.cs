using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
        .HasColumnName("us_id")
        .ValueGeneratedOnAdd();

        builder.Property(e => e.Cpf)
            .IsRequired()
            .HasMaxLength(11)
            .HasColumnName("us_cpf");

        builder.Property(e => e.Senha)
            .IsRequired()
            .HasColumnName("us_senha");

        builder.Property(e => e.Ativo)
            .IsRequired()
            .HasColumnName("us_ativo");

        builder.Property(e => e.Excluido)
            .IsRequired()
            .HasColumnName("us_excluido");

        builder.Property(e => e.MotivoExclusao)
            .HasMaxLength(255)
            .HasColumnName("us_motivo");

        builder.Property(e => e.PessoaIdQueExcluiu)
            .HasColumnName("pes_id_excluido");

        builder.Property(e => e.AtribuiLead)
            .HasColumnName("us_atribui_lead");

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(e => e.TipoUsuarioId)
            .HasColumnName("id_tipo_usuario");

        builder.HasOne(e => e.TipoUsuario);

        // entity.HasOne(d => d.TipoUsuario)
        //     .WithMany(p => p.Usuarios)
        //     .HasForeignKey(d => d.Id_Tipo_Usuario)
        //     .HasConstraintName("FK_Usuario_Tipo_Usuario");
    }
}
