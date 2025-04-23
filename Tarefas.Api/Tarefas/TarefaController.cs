using Microsoft.AspNetCore.Mvc;
using Tarefas.Aplicacao.Tarefas.Interfaces;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Api;

[ApiController]
[Route("api/tasks/")]
[Produces("application/json")]
[Consumes("application/json")]
public class TarefaController : ControllerBase
{
    private readonly IArmazenadorTarefa _armazenadorTarefa;

    public TarefaController(IArmazenadorTarefa armazenadorTarefa)
    {
        _armazenadorTarefa = armazenadorTarefa;
    }

    /// <summary>
    /// Cria uma tarefa nova para um user Id
    /// </summary>
    /// <param name="">A tarefa para requisitada</param>
    /// <returns>Os detalhes da tarefea criada</returns>
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarTarefa()
    {
        // var tarefinha = new Tarefa("teste", "teste", DateTime.Now, DateTime.Now, 1);
        // var tarefa = await _armazenadorTarefa.ArmazenarTarefa(tarefinha);
        return Ok("Tarefa criada!");
    }
    
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> ObterTarefa([FromRoute] string userId)
    {
        return Ok($"Tarefas do {userId} sendo listadas");
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> ConcluirTarefa([FromRoute] string id)
    {
        return Ok($"Tarefa {id} sendo concluída");
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> ExcluirTarefa([FromRoute] string id)
    {
        return Ok($"Tarefa {id} sendo concluída");
    }
    
}