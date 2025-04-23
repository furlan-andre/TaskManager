using Tarefas.Aplicacao.Tarefas.Dtos;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Aplicacao.Tarefas.Interfaces;

public interface IArmazenadorTarefa
{
    Task<TarefaDto> ArmazenarTarefa(ArmazenadorTarefaDto armazenadorTarefaDto);
}