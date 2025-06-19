using Microsoft.EntityFrameworkCore;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.Comuns.Infrastructure.Mappings;

namespace ValoReal.FGTS.Infrastructure;

public class FgtsDbContext : DbContext
{
    public FgtsDbContext(DbContextOptions<FgtsDbContext> options) : base(options) { }
    public DbSet<Emprestimo> Emprestimos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicação das configurações de mapeamento
        modelBuilder.ApplyConfiguration(new EmprestimoMapping());
    }
}