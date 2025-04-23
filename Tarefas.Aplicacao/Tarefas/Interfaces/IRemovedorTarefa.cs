namespace Tarefas.Aplicacao.Tarefas.Interfaces;

public interface IRemovedorTarefa
{
    Task ExcluirTarefaPorId(int id);
}