# MBAModulo1

Este projeto é uma aplicação web que utiliza ASP.NET Core, Entity Framework Core, e SQLite para gerenciamento de vendedores e produtos. A aplicação é dividida em três partes:

- **API**: Fornece os endpoints para o gerenciamento de vendedores e produtos.
- **Core**: Contém a lógica central do projeto.
- **MVC**: Interface do usuário para interagir com a API.

## Como executar o projeto localmente

1. Clone o repositório:
   ```bash
   git clone https://github.com/jmolaz/MBAModulo1.git
2. Navegue até a pasta do projeto
    cd MBAModulo1
3. Restaure as dependências:
    dotnet restore
4. Execute a API:
    dotnet run --project MBAModulo1.API
5. Execute o MVC:
    dotnet run --project MBAModulo1.MVC

OBS.: Caso haja a necessidades execute em terminais multiplos