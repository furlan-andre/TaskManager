using Bogus;
using Tarefas.Dominio.Base;
using Tarefas.Dominio.Tarefas;
using Tarefas.Test.Dominio.Builders;

namespace Tarefas.Test.Dominio.Tarefas;

  public class TarefaTests
    {
        private readonly Faker _faker = new();
        
        [Fact]
        public void NaoDevePermitirCriarTarefaSemTitulo()
        {
            // Arrange
            var tarefa = new TarefaBuilder().ComTitulo("").Build();
            var mensagemEsperada = StringResource.NECESSARIO_INFORMAR_O_TITULO;
            
            // Act
            tarefa.Validar();

            // Assert
            Assert.False(tarefa.Sucesso());
            Assert.Equal(mensagemEsperada, tarefa.ObterMensagens().FirstOrDefault());
        }
        
        [Fact]
        public void NaoDevePermitirCriarTarefaSemDescricao()
        {
            // Arrange
            var tarefa = new TarefaBuilder().ComDescricao("").Build();
            var mensagemEsperada = StringResource.NECESSARIO_INFORMAR_A_DESCRICAO;
            
            // Act
            tarefa.Validar();

            // Assert
            Assert.False(tarefa.Sucesso());
            Assert.Equal(mensagemEsperada, tarefa.ObterMensagens().FirstOrDefault());
        }
        
        [Fact]
        public void NaoDevePermitirCriarTarefaSemDataDeCriacao()
        { 
            // Arrange
            var tarefa = new TarefaBuilder().ComDataCriacao(DateTime.MinValue).Build();
            var mensagemEsperada = StringResource.NECESSARIO_INFORMAR_A_DATA_DE_CRIACAO;
            
            // Act
            tarefa.Validar();

            // Assert
            Assert.False(tarefa.Sucesso());
            Assert.Equal(mensagemEsperada, tarefa.ObterMensagens().FirstOrDefault());
        }
        
        [Fact]
        public void NaoDevePermitirCriarTarefaSemIdDoUsuario()
        {
            // Arrange
            var tarefa = new TarefaBuilder().ComIdDoUsuario(0).Build();
            var mensagemEsperada = StringResource.NECESSARIO_INFORMAR_O_ID_DO_USUARIO;
            
            // Act
            tarefa.Validar();

            // Assert
            Assert.False(tarefa.Sucesso());
            Assert.Equal(mensagemEsperada, tarefa.ObterMensagens().FirstOrDefault());
        }
        
        [Fact]
        public void DevePermitirCriarTarefa()
        {
            // Arrange
            var titulo = _faker.Lorem.Sentence(3);
            var descricao =  _faker.Lorem.Paragraph();
            var dataCriacao = DateTime.Now;
            var prazo = dataCriacao.AddDays(5);
            var userId = _faker.Random.Int(1, 1000);
            var status = StatusTarefa.Criada;

            // Act
            var tarefa = new Tarefa(titulo, descricao, dataCriacao, prazo, userId, status);

            // Assert
            Assert.Equal(titulo, tarefa.Titulo);
            Assert.Equal(descricao, tarefa.Descricao);
            Assert.Equal(dataCriacao, tarefa.DataCriacao);
            Assert.Equal(prazo, tarefa.PrazoFinalizacao);
            Assert.Equal(userId, tarefa.UsuarioId);
            Assert.Equal(StatusTarefa.Criada, tarefa.Status);
        }

        [Fact]
        public void DevePermitirConcluirTarefas()
        {
            // Arrange
            var tarefa = new TarefaBuilder().Build();

            // Act
            tarefa.ConcluirTarefa();

            // Assert
            Assert.Equal(StatusTarefa.Concluida, tarefa.Status);
        }
    }