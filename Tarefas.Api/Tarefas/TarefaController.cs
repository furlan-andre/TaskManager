using Microsoft.AspNetCore.Mvc;
using Tarefas.Aplicacao.Tarefas.Dtos;
using Tarefas.Aplicacao.Tarefas.Interfaces;

namespace Tarefas.Api.Tarefas;

[ApiController]
[Route("api/tasks/")]
[Produces("application/json")]
[Consumes("application/json")]
public class TarefaController : ControllerBase
{
    private readonly IArmazenadorTarefa _armazenadorTarefa;
    private readonly IConsultaTarefa _consultaTarefa;
    private readonly IConcluidorTarefa _concluidorTarefa;
    private readonly IRemovedorTarefa _removedorTarefa;

    public TarefaController(
        IArmazenadorTarefa armazenadorTarefa,
        IConsultaTarefa consultaTarefa,
        IConcluidorTarefa concluidorTarefa,
        IRemovedorTarefa removedorTarefa)
    {
        _armazenadorTarefa = armazenadorTarefa;
        _consultaTarefa = consultaTarefa;
        _concluidorTarefa = concluidorTarefa;
        _removedorTarefa = removedorTarefa;
    }

    /// <summary>
    /// Cria uma tarefa nova para um user Id
    /// </summary>
    /// <param name="armazenadorTarefaDto">Dados para criação de uma nova tarefa vinculada a um usuário</param>
    /// <returns>Os detalhes da tarefa criada</returns>
    [HttpPost]
    [ProducesResponseType(typeof(TarefaDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CriarTarefa([FromBody] ArmazenadorTarefaDto armazenadorTarefaDto)
    {
        var retorno = await _armazenadorTarefa.ArmazenarTarefa(armazenadorTarefaDto);
        if(retorno is null)
            return BadRequest();

        return Created("", retorno);
    }
    
    /// <summary>
    /// Obtem as tarefas do usuário por seu id
    /// </summary>
    /// <param name="userId">Id do usuário responsável pelas tarefas</param>
    /// <returns>As tarefas do usuário solicitado</returns>
    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(IEnumerable<TarefaDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ObterTarefa([FromRoute] int userId)
    {
        var resultado = await _consultaTarefa.ListarTarefasPorUsuarioId(userId);
        return Ok(resultado);
    }
    
    /// <summary>
    /// Altera o status da tarefa para Concluída
    /// </summary>
    /// <param name="id">Id da tarefa para realizar sua conclusão</param>
    [HttpPut("{id}/complete")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConcluirTarefa([FromRoute] int id)
    {
        await _concluidorTarefa.ConcluirTarefa(id);
        return Ok();
    }
    
    /// <summary>
    /// Remove a tarefa solicitada
    /// </summary>
    /// <param name="id">Id da tarefa para ser removida</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ExcluirTarefa([FromRoute] int id)
    {
        await _removedorTarefa.ExcluirTarefaPorId(id);
        return Ok();
    }
    
}