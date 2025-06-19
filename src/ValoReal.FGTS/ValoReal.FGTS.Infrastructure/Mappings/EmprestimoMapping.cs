using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("emprestimos_fgts");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
        .HasColumnName("emp_id")
        .ValueGeneratedOnAdd();

        builder.Property(e => e.IdPessoa)
            .IsRequired()
            .HasColumnName("pes_id");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(e => e.Ativo)
            .IsRequired()
            .HasColumnName("emp_ativo");

        builder.Property(e => e.IdEtapa)
            .IsRequired()
            .HasColumnName("et_id");

        builder.Property(e => e.IdStatus)
            .IsRequired()
            .HasColumnName("st_id");

        builder.Property(e => e.IdBanco)
            .HasColumnName("emp_ban_id");

        builder.Property(e => e.ValorBruto)
            .HasColumnName("emp_vl_bruto");

        builder.Property(e => e.ValorLiquido)
            .HasColumnName("emp_vl_liquido");

        builder.Property(e => e.ValorParcela)
            .HasColumnName("emp_vl_parcela");

        builder.Property(e => e.ValorPrazo)
            .HasColumnName("emp_vl_prazo");

        builder.Property(e => e.Tabela)
            .HasColumnName("emp_tabela");
    }
}
