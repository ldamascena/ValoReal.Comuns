using ValoReal.Comuns.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class TipoUsuarioMapping : IEntityTypeConfiguration<TipoUsuario>
{
    public void Configure(EntityTypeBuilder<TipoUsuario> builder)
    {
        builder.ToTable("tipo_usuario");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Descricao)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Ativo)
            .IsRequired();

        builder.Property(e => e.DataCadastro)
            .IsRequired()
            .HasColumnName("Data_Cadastro");

        builder.Property(e => e.DataAtualizacao)
            .HasColumnName("Data_Atualizacao");

        builder.HasMany(e => e.Usuarios)
            .WithOne(u => u.TipoUsuario)
            .HasForeignKey(u => u.TipoUsuarioId);
    }
}
