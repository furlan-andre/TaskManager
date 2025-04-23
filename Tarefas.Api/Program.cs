using System.Reflection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Tarefas.Aplicacao.InjecaoDependencias;
using Tarefas.Infra.Configurations;
using Tarefas.Infra.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AdicionarInjecaoInfra();
builder.Services.AdicionarInjecaoDependenciasAplicacao();

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();
builder.Services.AddDbContext<BancoDadosContexto>(options =>
    options.UseSqlite(connection));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async contexto =>
    {
        contexto.Response.ContentType = "application/json";
        var excecao = contexto.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (excecao != null)
        {
            var statusCode = excecao switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,  
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError         
            };

            contexto.Response.StatusCode = statusCode;

            var resposta = new
            {
                status = statusCode,
                mensagem = excecao.Message
            };

            await contexto.Response.WriteAsJsonAsync(resposta);
        }
    });
});


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BancoDadosContexto>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.MapControllers();
app.Run();