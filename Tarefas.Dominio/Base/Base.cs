namespace Tarefas.Dominio.Base;

public abstract class EntidadeBase
{
    public int Id { get; set; }

    internal List<string> Mensagens { get; set; } = new List<string>();

    public abstract void Validar();
    
    public bool Sucesso()
    {
        return !this.Mensagens.Any();
    }

    public List<string> ObterMensagens()
    {
        return this.Mensagens;
    }
}