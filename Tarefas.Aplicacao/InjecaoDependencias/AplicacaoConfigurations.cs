using Microsoft.Extensions.DependencyInjection;
using Tarefas.Aplicacao.Tarefas.Interfaces;
using Tarefas.Aplicacao.Tarefas.Services;

namespace Tarefas.Aplicacao.InjecaoDependencias;

public static class AplicacaoConfigurations
{
    public static IServiceCollection AdicionarInjecaoDependenciasAplicacao(this IServiceCollection services)
    {
        services.AddScoped<IArmazenadorTarefa, ArmazenadorTarefa>();
        services.AddScoped<IConcluidorTarefa, ConcluidorTarefas>();
        services.AddScoped<IConsultaTarefa, ConsultaTarefa>();
        services.AddScoped<IRemovedorTarefa, RemovedorTarefa>();
        return services;
    }
}