using Microsoft.EntityFrameworkCore;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Infrastructure.Mappings;

namespace ValoReal.Comuns.Infrastructure;

public class ComunsDbContext : DbContext
{
    public ComunsDbContext(DbContextOptions<ComunsDbContext> options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<TipoUsuario> TipoUsuario { get; set; } = null!;
    public DbSet<Pessoa> Pessoas { get; set; } = null!;
    public DbSet<Banco> Bancos { get; set; } = null!;
    public DbSet<DadosBancario> DadosBancarios { get; set; } = null!;
    public DbSet<Referencia> Referencias { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicação das configurações de mapeamento
        modelBuilder.ApplyConfiguration(new UsuarioMapping());
        modelBuilder.ApplyConfiguration(new TipoUsuarioMapping());
        modelBuilder.ApplyConfiguration(new PessoaMapping());
        modelBuilder.ApplyConfiguration(new BancoMapping());
        modelBuilder.ApplyConfiguration(new DadosBancarioMapping());
        modelBuilder.ApplyConfiguration(new ReferenciaMapping());
    }
}