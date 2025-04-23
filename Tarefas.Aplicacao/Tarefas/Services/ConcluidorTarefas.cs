using Tarefas.Aplicacao.Tarefas.Dtos;
using Tarefas.Aplicacao.Tarefas.Interfaces;
using Tarefas.Dominio.Base;

namespace Tarefas.Aplicacao.Tarefas.Services;

public class ConcluidorTarefas : IConcluidorTarefa
{
    private readonly ITarefaRepository _repository;

    public ConcluidorTarefas(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task ConcluirTarefa(int tarefaId)
    {
        var tarefa = await _repository.ObterTarefaPorIdAsync(tarefaId);
        if (tarefa is null)
            throw new KeyNotFoundException(StringResource.TAREFA_NAO_FOI_ENCONTRADA);
        
        tarefa.ConcluirTarefa();
        await _repository.AtualizarTarefaAsync(tarefa);
    }
}