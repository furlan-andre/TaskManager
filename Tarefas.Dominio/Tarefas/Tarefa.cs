using Tarefas.Dominio.Base;

namespace Tarefas.Dominio.Tarefas;


public class Tarefa : EntidadeBase
{
    public int Id { get; init; }
    public string Titulo { get; init; }
    public string Descricao { get; init; }
    public DateTime DataCriacao { get; init; } = DateTime.Now;
    public DateTime PrazoConclusao { get; init; }
    public int UsuarioId { get; init; }
    public StatusTarefa Status { get; private set; } = StatusTarefa.Criada;

    public Tarefa(string titulo, string descricao, DateTime prazoConclusao, int usuarioId, StatusTarefa status = StatusTarefa.Criada)
    {
        Titulo = titulo;
        Descricao = descricao;
        PrazoConclusao = prazoConclusao;
        UsuarioId = usuarioId;
        Status = status;
    }   
    
    public void ConcluirTarefa()
    {
        Status = StatusTarefa.Concluida;
    }
    
    public override void Validar()
    {
        if(string.IsNullOrWhiteSpace(Titulo))
            Mensagens.Add(StringResource.NECESSARIO_INFORMAR_O_TITULO);
        
        if(string.IsNullOrWhiteSpace(Descricao))
            Mensagens.Add(StringResource.NECESSARIO_INFORMAR_A_DESCRICAO);
        
        if(UsuarioId <= 0)
            Mensagens.Add(StringResource.NECESSARIO_INFORMAR_O_ID_DO_USUARIO);
    }
}