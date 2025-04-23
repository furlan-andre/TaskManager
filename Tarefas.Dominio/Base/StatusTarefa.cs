using System.ComponentModel;

namespace Tarefas.Dominio.Base;

public enum StatusTarefa
{
    [Description("Criada")]
    Criada = 0,
    [Description("Concluída")]
    Concluida = 1
}