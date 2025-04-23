using Moq;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Aplicacao.Tarefas.Services;
using Tarefas.Dominio.Base;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Test.Aplicacao.Tarefas;

public class ConcluidorTarefasTest
{
    private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
    private readonly ConcluidorTarefas _concluidorTarefas;

    public ConcluidorTarefasTest()
    {
        _tarefaRepositoryMock = new Mock<ITarefaRepository>();
        _concluidorTarefas = new ConcluidorTarefas(_tarefaRepositoryMock.Object);
    }

    [Fact]
    public async Task NaoDeveConcluirTarefaQuandoNaoEncontrada()
    {
        // Arrange
        var mensagemEsperada = StringResource.TAREFA_NAO_FOI_ENCONTRADA;

        // Act & Assert
        var acao = await Assert.ThrowsAsync<KeyNotFoundException>(() =>
            _concluidorTarefas.ConcluirTarefa(1));

        Assert.Equal(mensagemEsperada, acao.Message);
        _tarefaRepositoryMock.Verify(repo => repo.ObterTarefaPorIdAsync(It.IsAny<int>()), Times.Once);
        _tarefaRepositoryMock.Verify(repo => repo.AtualizarTarefaAsync(It.IsAny<Tarefa>()), Times.Never);
    }
    
    [Fact]
    public async Task DeveConcluirTarefaComSucesso()
    {
        // Arrange
        var tarefa = new Tarefa("Título", "Descrição",DateTime.Now.AddDays(2), 1);

        _tarefaRepositoryMock
            .Setup(repo => repo.ObterTarefaPorIdAsync(It.IsAny<int>()))
            .ReturnsAsync(tarefa);
        
        // Act
        await _concluidorTarefas.ConcluirTarefa(1);

        // Assert
        Assert.Equal(StatusTarefa.Concluida, tarefa.Status);
        _tarefaRepositoryMock.Verify(repo => repo.ObterTarefaPorIdAsync(It.IsAny<int>()), Times.Once);
        _tarefaRepositoryMock.Verify(repo => repo.AtualizarTarefaAsync(tarefa), Times.Once);
    }
}