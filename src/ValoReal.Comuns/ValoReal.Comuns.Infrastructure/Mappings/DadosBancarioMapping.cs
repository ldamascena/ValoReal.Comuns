using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class DadosBancarioMapping : IEntityTypeConfiguration<DadosBancario>
{
    public void Configure(EntityTypeBuilder<DadosBancario> builder)
    {
        builder.ToTable("DadosBancarios");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .HasColumnName("db_id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.IdPessoa)
            .HasColumnName("pes_id")
            .IsRequired();

        builder.Property(e => e.IdBanco)
            .HasColumnName("db_banco")
            .IsRequired();

        builder.Property(e => e.TipoConta)
            .HasMaxLength(50)
            .HasColumnName("db_tipo_conta")
            .IsRequired();

        builder.Property(e => e.Agencia)
            .HasMaxLength(20)
            .HasColumnName("db_agencia")
            .IsRequired();

        builder.Property(e => e.Conta)
            .HasMaxLength(20)
            .HasColumnName("db_conta")
            .IsRequired();

        builder.Property(e => e.Digito)
            .HasColumnName("db_digito");

        builder.Property(e => e.OpecacaoCaixa)
            .HasColumnName("db_op_caixa");

        builder.Property(e => e.Ativo)
            .HasMaxLength(1)
            .HasColumnName("db_ativo")
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne(d => d.Pessoa)
            .WithMany(p => p.DadosBancarios)
            .HasForeignKey(d => d.IdPessoa);

        builder.HasOne(d => d.Banco)
            .WithMany(b => b.DadosBancarios)
            .HasForeignKey(d => d.IdBanco);
    }
}
