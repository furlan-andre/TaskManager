using Microsoft.EntityFrameworkCore;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Dominio.Tarefas;
using Tarefas.Infra.Database;

namespace Tarefas.Infra.Tarefas;

public class TarefaRepository : ITarefaRepository
{
    private readonly BancoDadosContexto _context;

    public TarefaRepository(BancoDadosContexto context)
    {
        _context = context;
    }

    public async Task ArmazenarTarefa(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tarefa>> ObterTodasPorUsuarioIdAsync(int usuarioId)
    {
        return await _context.Tarefas.Where(t => t.UsuarioId == usuarioId)
                                     .ToListAsync();
    }

    public async Task<Tarefa> ObterTarefaPorIdAsync(int id)
    {
        return await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AtualizarTarefaAsync(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Tarefa tarefa)
    {
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
    }
}