using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValoReal.Comuns.Domain.Entities;

namespace ValoReal.Comuns.Infrastructure.Mappings;

public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoas");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id)
            .HasColumnName("pes_id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Nome)
            .HasMaxLength(255)
            .HasColumnName("pes_nome");

        builder.Property(e => e.Cpf)
            .HasMaxLength(11)
            .HasColumnName("pes_cpf");

        builder.Property(e => e.DataNascimento)
            .HasColumnName("pes_dtnasc");

        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .HasColumnName("pes_email");

        builder.Property(e => e.TelefoneFixo)
            .HasColumnName("pes_tel_fixo");

        builder.Property(e => e.TelefoneCelular)
            .HasColumnName("pes_tel_celular");

        builder.Property(e => e.Whatsapp)
            .HasMaxLength(20)
            .HasColumnName("pes_whats");

        builder.Property(e => e.Tpso_Id)
            .HasColumnName("tpso_id");

        builder.Property(e => e.Status)
            .HasMaxLength(1)
            .HasColumnName("pes_status");

        builder.Property(e => e.Tipo)
            .HasMaxLength(1)
            .HasColumnName("pes_tipo");

        builder.Property(e => e.RgFrente)
            .HasMaxLength(255)
            .HasColumnName("pes_rg_frente");

        builder.Property(e => e.RgVerso)
            .HasMaxLength(255)
            .HasColumnName("pes_rg_verso");

        builder.Property(e => e.Motivo)
            .HasMaxLength(500)
            .HasColumnName("pes_motivo");

        builder.Property(e => e.Excluido)
            .HasMaxLength(1)
            .HasColumnName("pes_excluido");

        builder.Property(e => e.EmailConfirmado)
            .HasMaxLength(1)
            .HasColumnName("pes_emailConfirmado");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at");

        builder.Property(e => e.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(e => e.Cep)
            .HasMaxLength(10)
            .HasColumnName("pes_cep");

        builder.Property(e => e.Endereco)
            .HasMaxLength(255)
            .HasColumnName("pes_endereco");

        builder.Property(e => e.Numero)
            .HasMaxLength(10)
            .HasColumnName("pes_endereco_numero");

        builder.Property(e => e.Complemento)
            .HasMaxLength(100)
            .HasColumnName("pes_endereco_complemento");

        builder.Property(e => e.Bairro)
            .HasMaxLength(100)
            .HasColumnName("pes_endereco_bairro");

        builder.Property(e => e.IdCidade)
            .HasColumnName("id_cidade");

        builder.Property(e => e.IdUf)
            .HasColumnName("id_uf");

        builder.Property(e => e.CiaeId)
            .HasColumnName("ciae_id");

        builder.Property(e => e.AceiteTermo)
            .HasColumnName("aceite_termo");

        builder.Property(e => e.FaturaEnergia)
            .HasMaxLength(255)
            .HasColumnName("pes_fatura_energia");

        builder.Property(e => e.Blacklist)
            .HasColumnName("blacklist");

        builder.Property(e => e.BlacklistMotivo)
            .HasMaxLength(500)
            .HasColumnName("blacklist_motivo");

        builder.Property(e => e.DataInclusaoBlacklist)
            .HasColumnName("dt_inclusao_blacklist");

        builder.Property(e => e.Selfie)
            .HasMaxLength(255)
            .HasColumnName("pes_selfie");

        builder.Property(e => e.NumeroRg)
            .HasMaxLength(20)
            .HasColumnName("pes_num_rg");

        builder.Property(e => e.NomeMae)
            .HasMaxLength(255)
            .HasColumnName("pes_nome_mae");

        builder.Property(e => e.IdTipoPix)
            .HasColumnName("pes_id_tipo_pix");

        builder.Property(e => e.ValorChavePix)
            .HasMaxLength(255)
            .HasColumnName("pes_vl_chave_pix");

        builder.Property(e => e.IdTipoEstadoCivil)
            .HasColumnName("pes_id_tipo_est_civil");

        builder.Property(e => e.Genero)
            .HasMaxLength(10)
            .HasColumnName("pes_genero");

        builder.Property(e => e.BancoPix)
            .HasColumnName("pes_ban_pix");

        builder.Property(e => e.Uuid)
            .HasMaxLength(36)
            .HasColumnName("uuid");

        builder.Property(e => e.RgEmissao)
            .HasMaxLength(50)
            .HasColumnName("pes_rg_emissao");

        builder.Property(e => e.ValorAdicional1)
            .HasMaxLength(255)
            .HasColumnName("pes_vl_adicional1");

        builder.Property(e => e.ValorAdicional2)
            .HasMaxLength(255)
            .HasColumnName("pes_vl_adicional2");

        builder.Property(e => e.UfNaturalidade)
            .HasMaxLength(2)
            .HasColumnName("pes_uf_naturalidade");

        builder.Property(e => e.CidadeNaturalidade)
            .HasMaxLength(255)
            .HasColumnName("pes_cidade_naturalidade");

        // Relacionamentos

        builder.HasOne(e => e.Banco)
            .WithMany(b => b.Pessoas)
            .HasForeignKey(e => e.BancoPix);

        builder.HasMany(e => e.DadosBancarios)
            .WithOne(b => b.Pessoa)
            .HasForeignKey(b => b.IdPessoa);

        builder.HasMany(e => e.Referencias)
            .WithOne(r => r.Pessoa)
            .HasForeignKey(r => r.IdPessoa);
    }
}
