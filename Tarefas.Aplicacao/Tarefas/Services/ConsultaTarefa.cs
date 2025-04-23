using Tarefas.Aplicacao.Extensions;
using Tarefas.Aplicacao.Tarefas.Dtos;
using Tarefas.Aplicacao.Tarefas.Interfaces;

namespace Tarefas.Aplicacao.Tarefas.Services;

public class ConsultaTarefa : IConsultaTarefa
{
    private readonly ITarefaRepository _repository;

    public ConsultaTarefa(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TarefaDto>> ListarTarefasPorUsuarioId(int usuarioId)
    {
        var tarefas = await _repository.ObterTodasPorUsuarioIdAsync(usuarioId);
        return tarefas.ToList().Select(t => new TarefaDto
        {
            Id = t.Id,
            Titulo = t.Titulo,
            Descricao = t.Descricao,
            DataCriacao = t.DataCriacao,
            PrazoConclusao = t.PrazoConclusao,
            UsuarioId = t.UsuarioId,
            Status = t.Status.GetDescription()
        }).ToList();
    }
}