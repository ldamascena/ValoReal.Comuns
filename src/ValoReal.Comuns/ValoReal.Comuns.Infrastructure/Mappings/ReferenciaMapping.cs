using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class ReferenciaMapping : IEntityTypeConfiguration<Referencia>
{
    public void Configure(EntityTypeBuilder<Referencia> builder)
    {
        builder.ToTable("Referencias");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ref_id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.IdPessoa)
            .HasColumnName("pes_id");

        builder.Property(e => e.Nome1)
            .HasMaxLength(255)
            .HasColumnName("ref_nome_1")
            .IsRequired();

        builder.Property(e => e.Nome2)
            .HasMaxLength(255)
            .HasColumnName("ref_nome_2");

        builder.Property(e => e.Telefone1)
            .HasColumnName("ref_tel_1")
            .IsRequired();

        builder.Property(e => e.Telefone2)
            .HasColumnName("ref_tel_2");

        builder.Property(e => e.Ativo)
            .HasMaxLength(1)
            .HasColumnName("ref_ativo");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne(d => d.Pessoa)
            .WithMany(p => p.Referencias)
            .HasForeignKey(d => d.IdPessoa);
    }
}
