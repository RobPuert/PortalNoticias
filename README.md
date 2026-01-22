# Projeto MVC .NET – Avaliação Técnica

## Descrição:

Este projeto foi desenvolvido como parte de uma **avaliação técnica** com o objetivo de demonstrar conhecimentos em **ASP.NET MVC**, boas práticas de organização de código, separação de responsabilidades e uso de recursos modernos da plataforma .NET.

A aplicação permite o gerenciamento de entidades básicas (Tag e Noticias) com operações de **CRUD** e persistência de dados.

---

## Tecnologias Utilizadas:

- **.NET 10**
- **ASP.NET MVC**
- **Entity Framework Core**
- **Banco de Dados:** SQL Server
- **Migrations**

---

## Arquitetura e Decisões Técnicas:

- Utilização do padrão **MVC (Model–View–Controller)** para separação clara de responsabilidades
- Camada de acesso a dados utilizando **Entity Framework Core**
- Validações realizadas no **backend**, garantindo integridade dos dados
- Organização do projeto visando **legibilidade, manutenção e escalabilidade**
- Uso de **ViewModels** quando necessário para evitar exposição direta das entidades

---

## Como Executar o Projeto:

### Pré-requisitos:
- .NET SDK instalado
- Banco de dados configurado (SQL Server)

### Passos:

1. Clone o repositório;
2. Configure a connection string no arquivo em appsettings.json;
3. Execute as migrations (dotnet ef database update);
4. Execute o projeto (dotnet run);
5. O projeto deve iniciar no seu navegador favorito.

---

## Funcionalidades Implementadas

- Listagem de Tags;
- Criação de novas Tags;
- Edição de Tags;
- Exclusão de Tags com confirmação;
- Listagem de Noticias;
- Criação de novas Notícias podendo relacionar com N Tags;
- Edição de Notícias;
- Exclusão de Notícias com confirmação;
- Tratamento básico de erros;

---

## Pontos de Melhoria / Próximos Passos:

- Implementação de layout mais elegante para o front;
- Implementação de testes automatizados (xUnit / NUnit);
- Autenticação e autorização;
- Logs estruturados;
- Paginação e filtros avançados;
- Camada de serviços mais desacoplada;
- Containerização com Docker;

--- 

## O foco deste projeto foi demonstrar:

- Domínio dos conceitos fundamentais do ASP.NET MVC;
- Organização de código;
- Boas práticas de desenvolvimento;
- Capacidade de evoluir a solução;

---

## Autor:
Robson F. Puert
- https://www.linkedin.com/in/robson-puert-3973281bb/
- https://github.com/RobPuert
