using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Infra.Configurations;

public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Titulo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Descricao)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(t => t.DataCriacao)
            .IsRequired();

        builder.Property(t => t.PrazoConclusao)
            .IsRequired();

        builder.Property(t => t.UsuarioId)
            .IsRequired();

        builder.Property(t => t.Status)
            .HasConversion<string>()
            .IsRequired();
    }
}