using Moq;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Aplicacao.Tarefas.Services;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Test.Aplicacao.Tarefas;

public class ConsultaTarefaTest
{
    private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
    private readonly ConsultaTarefa _consultaTarefa;

    public ConsultaTarefaTest()
    {
        _tarefaRepositoryMock = new Mock<ITarefaRepository>();
        _consultaTarefa = new ConsultaTarefa(_tarefaRepositoryMock.Object);
    }
    
    [Fact]
    public async Task NaoDeveListarTarefasQuandoNaoExistirTarefa()
    {
        // Arrange
        _tarefaRepositoryMock
            .Setup(repo => repo.ObterTodasPorUsuarioIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new List<Tarefa>());

        // Act
        var resultado = await _consultaTarefa.ListarTarefasPorUsuarioId(1);

        // Assert
        Assert.NotNull(resultado);
        Assert.Empty(resultado);
        _tarefaRepositoryMock.Verify(repo => repo.ObterTodasPorUsuarioIdAsync(It.IsAny<int>()), Times.Once);
    }
    
    [Fact]
    public async Task DeveListarTarefasDoUsuarioComSucesso()
    {
        // Arrange
        var tarefas = new List<Tarefa>
        {
            new ("Titulo 1", "Descricao 1", DateTime.Now.AddDays(1), 1),
            new ("Titulo 2", "Descricao 2", DateTime.Now.AddDays(2), 1)
        };
        _tarefaRepositoryMock
            .Setup(repo => repo.ObterTodasPorUsuarioIdAsync(It.IsAny<int>()))
            .ReturnsAsync(tarefas);
    
        // Act
        var resultado = await _consultaTarefa.ListarTarefasPorUsuarioId(1);
    
        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(2, resultado.Count());
        Assert.All(resultado, t => Assert.Equal(1, t.UsuarioId));
        _tarefaRepositoryMock.Verify(repo => repo.ObterTodasPorUsuarioIdAsync(It.IsAny<int>()), Times.Once);
    }
}