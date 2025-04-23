using Microsoft.Extensions.DependencyInjection;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Infra.Tarefas;

namespace Tarefas.Infra.Configurations;

public static class InfraConfigurations
{
    public static IServiceCollection AdicionarInjecaoInfra(this IServiceCollection services)
    {

        services.AddScoped<ITarefaRepository, TarefaRepository>();

        return services;
    }
}