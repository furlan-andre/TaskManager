## Sobre o projeto
- Projeto de teste sobre conhecimento técnico

## Features
- Desenvolvido em C# com .NET Core 8
- Usando banco de dados InMemory (SQLite)
- Usando conceitos do DDD
- Usando diretrizes do Clean Code
- Usando xUnit, FluentAssertions, Moq, Faker, Builder Pattern
- Usando Onion Archtecture
- Usando documentação viva com Swagger

## Como usar
- Para se testar de forma automática é só usar a plataforma de testes do projeto Tarefas.Test
- Para se utlizar (testes manuais) é preciso setar o projeto Tarefas.Api como startup e rodar em debug mode.
- Esta configurado para abrir automaticamente a pagina do Swagger na porta 5099.
- Endereço do swagger: http://localhost:5099/swagger/index.html
- Como foi feito com documentação viva com Swagger, é auto descritivo e serve de manual.
- Como o banco utilizado é InMemory, o mesmo é apagado toda vez que a aplicação é desligada.