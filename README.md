# AddressManagerApp

## Descrição do Projeto

O **AddressManagerApp** é uma aplicação web desenvolvida em C# utilizando o framework ASP.NET MVC, que permite aos usuários gerenciar um CRUD de endereços. A aplicação possibilita o cadastro manual de endereços ou a busca de informações através da integração com a API do ViaCEP, além de oferecer a opção de exportar os endereços salvos para um arquivo CSV.

## Funcionalidades

- Autenticação de usuário com validação de credenciais.
- Redirecionamento para a página de endereços após login bem-sucedido.
- CRUD de endereços:
  - Adicionar, visualizar, editar e excluir endereços.
  - Cada endereço contém: CEP, logradouro, complemento (opcional), bairro, cidade, UF e número.
- Integração com a API do ViaCEP para consulta de endereço a partir do CEP.
- Exportação de endereços salvos para um arquivo CSV.
  
## Estrutura do Banco de Dados

### Tabela `Usuarios`

- **Id**: Identificador único do usuário (chave primária).
- **Nome**: Nome completo do usuário.
- **Usuario**: Nome de usuário utilizado para login.
- **Senha**: Senha do usuário.

### Tabela `Enderecos`

- **Id**: Identificador único do endereço (chave primária).
- **Cep**: CEP do endereço.
- **Logradouro**: Rua ou avenida do endereço.
- **Complemento**: Informação complementar do endereço (opcional).
- **Bairro**: Bairro do endereço.
- **Cidade**: Cidade do endereço.
- **Uf**: Unidade federativa (estado) do endereço.
- **Numero**: Número do endereço.
- **UsuarioId**: Referência ao usuário proprietário do endereço (chave estrangeira).

## Tecnologias Utilizadas

- **ASP.NET MVC**: Framework para desenvolvimento web.
- **Entity Framework Core**: Mapeamento objeto-relacional para interação com o banco de dados.
- **SQL Server**: Banco de dados relacional utilizado.
- **HTML, CSS e JavaScript**: Tecnologias para o frontend.
- **ViaCEP API**: Serviço para busca de endereços a partir de CEP.
- **Autenticação com Cookies**: Utilizada para gerenciar sessões de login.

## Como Executar o Projeto

### Pré-requisitos

- .NET SDK 6.0 ou superior
- SQL Server
- Ferramenta de gerenciamento de pacotes NuGet

### Passos para Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/address-manager-app.git

    Navegue até o diretório do projeto:

    bash

cd address-manager-app

Restaure as dependências do projeto:

bash

dotnet restore

Configure a string de conexão no arquivo appsettings.json de acordo com seu servidor SQL Server.

Crie o banco de dados e aplique as migrações:

bash

dotnet ef database update

Execute a aplicação:

bash

    dotnet run

    Acesse a aplicação em http://localhost:5000.

Scripts de Criação do Banco de Dados

Os scripts de criação das tabelas Usuarios e Enderecos podem ser encontrados no diretório SqlScripts.
Como Contribuir

    Faça um fork do projeto.
    Crie uma branch para a sua funcionalidade (git checkout -b feature/nova-funcionalidade).
    Commit suas mudanças (git commit -m "Implementação de nova funcionalidade").
    Faça o push da branch (git push origin feature/nova-funcionalidade).
    Abra um Pull Request.
