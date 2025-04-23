using FluentAssertions;
using Moq;
using Tarefas.Aplicacao.Extensions;
using Tarefas.Aplicacao.Tarefas;
using Tarefas.Aplicacao.Tarefas.Dtos;
using Tarefas.Aplicacao.Tarefas.Services;
using Tarefas.Dominio.Base;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Test.Aplicacao.Tarefas
{
    public class ArmazenadorTarefaTest
    {
        private readonly Mock<ITarefaRepository> _tarefaRepositoryMock;
        private readonly ArmazenadorTarefa _armazenadorTarefa;
        
        public ArmazenadorTarefaTest()
        {
            _tarefaRepositoryMock = new Mock<ITarefaRepository>();
            _armazenadorTarefa = new ArmazenadorTarefa(_tarefaRepositoryMock.Object);
        }
        
        [Fact]
        public async Task NaoDeveArmazenarTarefaComErroDeValidacao()
        {
            // Arrange
            var dtoSemUsuarioId = new ArmazenadorTarefaDto
            {
                Titulo = "Teste de tarefa",
                Descricao = "Descrição de teste",
                PrazoConclusao = DateTime.Today.AddDays(5)
            };

            // Act
            var acao = async () => await _armazenadorTarefa.ArmazenarTarefa(dtoSemUsuarioId);
            
            // Assert
            await acao.Should().ThrowAsync<ArgumentException>();
            _tarefaRepositoryMock.Verify(r => r.ArmazenarTarefa(It.IsAny<Tarefa>()), Times.Never);
        }
        
        [Fact]
        public async Task DeveArmazenarTarefaComSucesso()
        {
            // Arrange
            var armazenadorTarefaDto = new ArmazenadorTarefaDto
            {
                Titulo = "Teste de tarefa",
                Descricao = "Descrição de teste",
                PrazoConclusao = DateTime.Today.AddDays(5),
                UsuarioId = 1
            };

            // Act
            var resultado = await _armazenadorTarefa.ArmazenarTarefa(armazenadorTarefaDto);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(armazenadorTarefaDto.Titulo, resultado.Titulo);
            Assert.Equal(armazenadorTarefaDto.Descricao, resultado.Descricao);
            Assert.Equal(armazenadorTarefaDto.PrazoConclusao, resultado.PrazoConclusao);
            Assert.Equal(armazenadorTarefaDto.UsuarioId, resultado.UsuarioId);
            Assert.Equal(StatusTarefa.Criada.GetDescription(), resultado.Status);
            _tarefaRepositoryMock.Verify(r => r.ArmazenarTarefa(It.IsAny<Tarefa>()), Times.Once);
        }
    }
}