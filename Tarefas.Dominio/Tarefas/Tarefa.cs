using Tarefas.Dominio.Base;

namespace Tarefas.Dominio.Tarefas;


public class Tarefa : EntidadeBase
{
    public int Id { get; init; }
    public string Titulo { get; init; }
    public string Descricao { get; init; }
    public DateTime DataCriacao { get; init; } = DateTime.Now;
    public DateTime PrazoFinalizacao { get; init; }
    public int UserId { get; init; }
    public StatusTarefa Status { get; private set; } = StatusTarefa.Criada;

    public Tarefa(string titulo, string descricao, DateTime dataCriacao, DateTime prazoFinalizacao, int userId, StatusTarefa status)
    {
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = dataCriacao;
        PrazoFinalizacao = prazoFinalizacao;
        UserId = userId;
        Status = status;
    }   
    
    public void ConcluirTarefa()
    {
        Status = StatusTarefa.Concluida;
    }
    
    public override void Validar()
    {
        if(string.IsNullOrWhiteSpace(Titulo))
            Mensagens.Add("É necessário informar o titulo.");
        
        if(string.IsNullOrWhiteSpace(Descricao))
            Mensagens.Add("É necessário informar a descrição");
        
        if(DataCriacao == DateTime.MinValue)
            Mensagens.Add("É necessário informar a data de criação");
        
        if(UserId <= 0)
            Mensagens.Add("É necessário informar o id do usuário");
        
        throw new NotImplementedException();
    }
}