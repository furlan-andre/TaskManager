namespace Tarefas.Aplicacao.Tarefas.Dtos;

public record ArmazenadorTarefaDto
{
    /// <summary>
    /// Título a ser atribuído a nova tarefa
    /// </summary>
    public string Titulo { get; init; }
    
    /// <summary>
    /// Descrição a ser atribuída a nova tarefa
    /// </summary>
    public string Descricao { get; init; }
    
    /// <summary>
    /// Prazo de conclusão para a nova tarefa
    /// </summary>
    public DateTime PrazoConclusao { get; init; }
    
    /// <summary>
    /// Usuário vinculado a nova tarefa
    /// </summary>
    public int UsuarioId { get; init; }
}