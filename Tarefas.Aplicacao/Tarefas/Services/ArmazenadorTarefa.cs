using System.Net;
using Tarefas.Aplicacao.Extensions;
using Tarefas.Aplicacao.Tarefas.Dtos;
using Tarefas.Aplicacao.Tarefas.Interfaces;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Aplicacao.Tarefas.Services;

public class ArmazenadorTarefa : IArmazenadorTarefa
{
    private readonly ITarefaRepository _repository;

    public ArmazenadorTarefa(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<TarefaDto> ArmazenarTarefa(ArmazenadorTarefaDto armazenadorTarefaDto)
    {
        var tarefa = new Tarefa(
            armazenadorTarefaDto.Titulo,
            armazenadorTarefaDto.Descricao,
            armazenadorTarefaDto.PrazoConclusao,
            armazenadorTarefaDto.UsuarioId);
        
        tarefa.Validar();
        if(!tarefa.Sucesso())
            throw new ArgumentException(string.Join(", ", tarefa.ObterMensagens()));
        
        await _repository.ArmazenarTarefa(tarefa);
        
        return new TarefaDto()
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            PrazoConclusao = tarefa.PrazoConclusao,
            UsuarioId = tarefa.UsuarioId,
            Status = tarefa.Status.GetDescription()
        };
    }
}