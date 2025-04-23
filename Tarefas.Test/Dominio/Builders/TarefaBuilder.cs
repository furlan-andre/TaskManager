using Bogus;
using Tarefas.Dominio.Base;
using Tarefas.Dominio.Tarefas;

namespace Tarefas.Test.Dominio.Builders
{
    public class TarefaBuilder
    {
        private readonly Faker _faker = new();

        private int _id;
        private string _titulo;
        private string _descricao;
        private DateTime _dataCriacao;
        private DateTime _prazoFinalizacao;
        private int _usuarioId;
        private StatusTarefa _status;

        public TarefaBuilder()
        {
            _id = _faker.Random.Int(1, 1000);
            _titulo = _faker.Lorem.Sentence(3);
            _descricao = _faker.Lorem.Paragraph();
            _prazoFinalizacao = _dataCriacao.AddDays(_faker.Random.Int(1, 30));
            _usuarioId = _faker.Random.Int(1, 1000);
            _status = StatusTarefa.Criada;
        }

        public TarefaBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public TarefaBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;
            return this;
        }

        public TarefaBuilder ComDataCriacao(DateTime data)
        {
            _dataCriacao = data;
            return this;
        }

        public TarefaBuilder ComPrazoFinalizacao(DateTime prazo)
        {
            _prazoFinalizacao = prazo;
            return this;
        }

        public TarefaBuilder ComIdDoUsuario(int usuarioId)
        {
            _usuarioId = usuarioId;
            return this;
        }

        public TarefaBuilder ComStatus(StatusTarefa status)
        {
            _status = status;
            return this;
        }

        public Tarefa Build()
        {
            return new Tarefa(_titulo, _descricao, _prazoFinalizacao, _usuarioId, _status);
        }
    }
}