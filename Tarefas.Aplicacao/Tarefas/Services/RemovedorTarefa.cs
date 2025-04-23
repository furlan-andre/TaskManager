using Tarefas.Aplicacao.Tarefas.Interfaces;
using Tarefas.Dominio.Base;

namespace Tarefas.Aplicacao.Tarefas.Services;

public class RemovedorTarefa : IRemovedorTarefa
{
    public readonly ITarefaRepository _tarefaRepository;

    public RemovedorTarefa(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task ExcluirTarefaPorId(int id)
    {
        var tarefa = await _tarefaRepository.ObterTarefaPorIdAsync(id);
        if(tarefa is null)
            throw new KeyNotFoundException(StringResource.TAREFA_NAO_FOI_ENCONTRADA);

        await _tarefaRepository.RemoverAsync(tarefa);
    }
}