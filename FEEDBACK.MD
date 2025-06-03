# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - O projeto MVC possui views para cadastro, listagem e edição de produtos e categorias, alinhadas às funcionalidades esperadas.
    - As rotas estão definidas adequadamente para os principais recursos.

### Design
  - O design é simples, mas funcional. Cumpre o mínimo esperado para um painel administrativo de e-commerce.

### Funcionalidade
  * Pontos positivos:
    - Funcionalidades básicas de CRUD para produtos e categorias foram implementadas no MVC.
    - As categorias são reutilizáveis conforme esperado.

  * Pontos negativos:
    - A ausência de registro de usuário via MVC compromete a cobertura funcional esperada para essa camada.

## Back End

### Arquitetura
  * Pontos positivos:
    - Arquitetura enxuta, com uso de apenas 3 camadas (MVC, API e Core).
    - Separação de API e MVC sem consumo interno entre elas, conforme especificado.

  * Pontos negativos:
    - A ausência de implementações na camada Core/Shared reutilizável gera duplicação de código entre MVC e API.
    - Falta de abstração em repositórios ou serviços dificulta a manutenibilidade e reutilização de lógica.
    - Implementação direta de lógica nas controllers viola o princípio de separação de responsabilidades.

### Funcionalidade
  * Pontos positivos:
    - A API implementa autenticação com JWT.
    - Cadastro e gerenciamento de produtos e categorias presentes na API.
    - Uso do EF Core com SQLite implementado.

  * Pontos negativos:
    - Entidade `Vendedor` herda diretamente de `IdentityUser`, violando o requisito de separação entre usuário do Identity e entidade de domínio.
    - O ID do `AspNetUser` não é utilizado como chave compartilhada no `Vendedor` de forma independente.
    - Não há seed automático de dados nem migrações automatizadas no startup da aplicação (`DbMigrationHelper` ou equivalente ausente).

### Modelagem
  * Pontos positivos:
    - A modelagem segue padrões anêmicos, com entidades simples e aderentes ao domínio.

  * Pontos negativos:
    - A herança entre `Vendedor` e `IdentityUser` causa acoplamento indevido e quebra a arquitetura sugerida.

## Projeto

### Organização
  * Pontos positivos:
    - Camadas separadas em projetos distintos.
    - Estrutura de pastas padrão respeitada.

  * Pontos negativos:
    - Projeto de domínio (`Core`) não incluso no arquivo `.sln`, indicando falha de organização.
    - Falta uso da pasta `src` na raiz do projeto.
    - Diretórios e arquivos diversos fora do escopo técnico esperável estão presentes na raiz.
    - Projeto versionado com todos os binários

### Documentação
  * Pontos positivos:
    - README.md presente com informações básicas.
    - Swagger implementado na API.

  * Pontos negativos:
    - Arquivo `FEEDBACK.md` ausente.
    - README com informações limitadas sobre execução e estrutura.

### Instalação
  * Pontos positivos:
    - SQLite configurado como provider de desenvolvimento.
  
  * Pontos negativos:
    - Ausência de seed de dados automático.
    - Migrations não executadas no startup.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 7        | 2,1                                      |
| **Qualidade do Código**       | 20%      | 8        | 1,6                                      |
| **Eficiência e Desempenho**   | 20%      | 6        | 1,2                                      |
| **Inovação e Diferenciais**   | 10%      | 7        | 0,7                                      |
| **Documentação e Organização**| 10%      | 7        | 0,7                                      |
| **Resolução de Feedbacks**    | 10%      | 7        | 0,7                                      |
| **Total**                     | 100%     | -        | **7,0**                                  |

## 🎯 **Nota Final: 7 / 10**
