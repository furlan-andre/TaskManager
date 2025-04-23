using Microsoft.EntityFrameworkCore;
using Tarefas.Dominio.Tarefas;
using Tarefas.Infra.Configurations;

namespace Tarefas.Infra.Database;

public class BancoDadosContexto : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }

    public BancoDadosContexto(DbContextOptions<BancoDadosContexto> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TarefaConfiguration());
    }
}