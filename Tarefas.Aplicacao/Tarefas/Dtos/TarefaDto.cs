namespace Tarefas.Aplicacao.Tarefas.Dtos;

public record TarefaDto
{
    public int Id { get; init; }
    public string Titulo { get; init; }
    public string Descricao { get; init; }
    public DateTime DataCriacao { get; init; }
    public DateTime PrazoConclusao { get; init; }
    public int UsuarioId { get; init; }
    public string Status { get; init; }
}