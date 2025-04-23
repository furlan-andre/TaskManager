namespace Tarefas.Aplicacao.Tarefas.Interfaces;

public interface IConcluidorTarefa
{
    Task ConcluirTarefa(int tarefaId);
}