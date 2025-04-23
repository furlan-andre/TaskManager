using Tarefas.Aplicacao.Tarefas.Dtos;

namespace Tarefas.Aplicacao.Tarefas.Interfaces;

public interface IConsultaTarefa
{
    Task<IEnumerable<TarefaDto>> ListarTarefasPorUsuarioId(int usuarioId);
}