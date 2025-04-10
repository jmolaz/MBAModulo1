# Feedback - Avaliação Geral

## Front End
### Navegação
* **Pontos Positivos:**
  - A estrutura de navegação base está presente no layout do MVC.
  - O menu exibe links para login, logout e identidade do usuário autenticado.

* **Pontos Negativos:**
  - Não existem controllers ou views implementadas para Produtos ou Categorias no MVC.
  - A navegação é limitada apenas à autenticação, não cumprindo os casos de uso do escopo.

### Design
* **Pontos Positivos:**
  - Será avaliado na entrega final

* **Pontos Negativos:**
  - Será avaliado na entrega final

### Funcionalidade
* **Pontos Positivos:**
  - O sistema de login e registro via ASP.NET Core Identity está implementado no MVC.

* **Pontos Negativos:**
  - O MVC **não implementa o CRUD de Produtos e Categorias**, contrariando o escopo.
  - Não existem views nem rotas para manipulação das entidades principais.
  - A aplicação MVC atualmente serve apenas como portal de autenticação.

## Back End
### Arquitetura
* **Pontos Positivos:**
  - O projeto está dividido fisicamente em três camadas: `MBAModulo1.MVC`, `MBAModulo1.API`, e `MBAModulo1.Core`.
  - A estrutura da camada Core está organizada e reutilizável.

### Funcionalidade
* **Pontos Positivos:**
  - O CRUD de Produtos e Categorias está completamente implementado na API.
  - A autenticação via JWT está funcional e protege os endpoints de escrita.
  - A consulta de produtos públicos sem autenticação está implementada corretamente.  

* **Pontos Negativos:**
  - O vínculo do vendedor e usuário não é feito via UserId do Identity.
  - O método de seed não cria um usuário com dados conhecidos para testes rápidos da API.

### Modelagem

* **Pontos Negativos:**
  - Nem todas entidades ainda foram definidas

## Projeto
### Organização

   - Será avaliado na entrega final

### Documentação
* **Pontos Negativos:**
  - O repositório não contém `README.md`.
  - Ausência de instruções para execução do projeto localmente.
  - Não há documentação de endpoints nem arquivo `FEEDBACK.md`.

### Instalação
* **Pontos Positivos:**
  - Uso de SQLite para ambiente de desenvolvimento está configurado corretamente.

* **Pontos Negativos:**
  - Não encontrei o seed de dados
