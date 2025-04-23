using Moq;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Aplicacao.Tarefas.Services;
using Tarefas.Dominio.Base;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Test.Aplicacao.Tarefas;

public class RemovedorTarefaTest
{
    private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
    private readonly RemovedorTarefa _removedorTarefa;

    public RemovedorTarefaTest()
    {
        _tarefaRepositoryMock = new Mock<ITarefaRepository>();
        _removedorTarefa = new RemovedorTarefa(_tarefaRepositoryMock.Object);
    }
    
    [Fact]
    public async Task NaoDeveRemovertarefaNaoExistente()
    {
        // Arrange
        var mensagemEsperada = StringResource.TAREFA_NAO_FOI_ENCONTRADA;
        // Act & Assert
        var excecao = await Assert.ThrowsAsync<KeyNotFoundException>(
            () => _removedorTarefa.ExcluirTarefaPorId(1));

        Assert.Equal(mensagemEsperada, excecao.Message);

        _tarefaRepositoryMock.Verify(r => r.ObterTarefaPorIdAsync(It.IsAny<int>()), Times.Once);
        _tarefaRepositoryMock.Verify(r => r.RemoverAsync(It.IsAny<Tarefa>()), Times.Never);
    }
    
    [Fact]
    public async Task ExcluirTarefaPorId_DeveRemoverTarefa_QuandoTarefaExistir()
    {
        // Arrange
        var tarefa = new Tarefa("Titulo", "Descricao",DateTime.Now.AddDays(1), 1);

        _tarefaRepositoryMock
            .Setup(r => r.ObterTarefaPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(tarefa);

        _tarefaRepositoryMock
            .Setup(r => r.RemoverAsync(tarefa))
            .Returns(Task.CompletedTask);

        // Act
        await _removedorTarefa.ExcluirTarefaPorId(1);

        // Assert
        _tarefaRepositoryMock.Verify(r => r.ObterTarefaPorIdAsync(It.IsAny<int>()), Times.Once);
        _tarefaRepositoryMock.Verify(r => r.RemoverAsync(tarefa), Times.Once);
    }
}