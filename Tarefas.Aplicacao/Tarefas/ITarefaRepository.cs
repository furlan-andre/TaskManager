using Tarefas.Dominio.Tarefas;

namespace Tarefas.Aplicacao.Tarefas;

public interface ITarefaRepository
{
    Task ArmazenarTarefa(Tarefa tarefa);
    Task<IEnumerable<Tarefa>> ObterTodasPorUsuarioIdAsync(int usuarioId);
    Task<Tarefa> ObterTarefaPorIdAsync(int id);
    Task AtualizarTarefaAsync(Tarefa tarefa);
    Task RemoverAsync(Tarefa tarefa);
}