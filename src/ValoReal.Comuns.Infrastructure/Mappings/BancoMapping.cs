using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class BancoMapping : IEntityTypeConfiguration<Banco>
{
    public void Configure(EntityTypeBuilder<Banco> builder)
    {
        builder.ToTable("Bancos");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ban_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Codigo)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("ban_codigo");

        builder.Property(e => e.Descricao)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("ban_descricao");
            
        builder.Property(e => e.Ativo)
            .IsRequired()
            .HasMaxLength(1)
            .HasColumnName("ban_ativo");

        builder.Property(e => e.Ordem)
            .IsRequired()
            .HasColumnName("ban_ordem");

        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasMany(e => e.Pessoas)
            .WithOne(p => p.Banco)
            .HasForeignKey(p => p.BancoPix);
    }
}
