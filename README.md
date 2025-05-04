# MBAModulo1 - Aplicação de Gestão com MVC e API RESTful

## 1. Apresentação

Bem-vindo ao repositório do projeto **MBAModulo1**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e faz parte do módulo *Introdução ao Desenvolvimento ASP.NET Core*. 

O objetivo é construir uma aplicação web com funcionalidades de autenticação e CRUD de produtos e categorias, utilizando ASP.NET Core com arquitetura baseada em MVC e API RESTful, com comunicação entre os projetos via `HttpClient`.

A API utiliza SQLite como banco de dados e inclui um usuário padrão para facilitar o acesso imediato.

### Autor
- Jefferson Molaz


## 2. Proposta do Projeto

O projeto consiste em:

- **Aplicação MVC**: Interface web para interação com produtos e categorias.
- **API RESTful**: Camada de serviços para manipulação dos dados.
- **Autenticação e Autorização**: Implementação de controle de acesso usando ASP.NET Core Identity.
- **Acesso a Dados**: Utilização de Entity Framework Core com banco de dados SQLite.

---

## 3. Tecnologias Utilizadas

**Linguagem de Programação:** C#

**Frameworks:**
- ASP.NET Core MVC
- ASP.NET Core Web API
- Entity Framework Core

**Banco de Dados:** SQLite

**Autenticação e Autorização:**
- ASP.NET Core Identity
- JWT (JSON Web Token) para autenticação na API

**Front-end:**
- Razor Pages/Views
- HTML/CSS para estilização básica

**Documentação da API:** Swagger

## 4. Estrutura do Projeto

A estrutura do projeto é organizada da seguinte forma:

- **API**: Fornece os endpoints para o gerenciamento de Produto, Categoria e Autenticação.
- **Core**: Contém a lógica central do projeto.
- **MVC**: Interface do usuário para interagir com a API.

## 5. Como Executar o Projeto

   Clone o Repositório:

- git clone https://github.com/jmolaz/MBAModulo1.git
- cd nome-do-repositorio
- Configuração do Banco de Dados:

- Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos
- Executar a Aplicação MVC:
- Usuário Padrão
- **Email:** teste@teste.com.br  
- **Senha:** T123@abc

- cd src/Blog.Mvc/
- dotnet run
- Acesse a aplicação em: http://localhost:5112
- Executar a API:

- cd src/Blog.Api/
- dotnet run
- Acesse a documentação da API em: http://localhost:5058/swagger/index.html 




