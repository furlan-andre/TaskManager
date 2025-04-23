using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Infra.Database;
using Tarefas.Infra.Tarefas;

namespace Tarefas.Infra.Configurations;

public static class InfraConfigurations
{
    public static IServiceCollection AdicionarInfra(this IServiceCollection services)
    {
        services.AddDbContext<BancoDadosContexto>(options =>
        {
            options.UseSqlite("DataSource=:memory:");
        });
        
        services.AddScoped<ITarefaRepository, TarefaRepository>();

        return services;
    }
}