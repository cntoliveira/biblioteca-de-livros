# 📚 BIBLIOTECA DE LIVROS



## 🧾 Descrição

> "Esta API tem como objetivo facilitar o gerenciamento de um acervo de livros, permitindo operações como cadastro, consulta, edição e exclusão de registros de forma simples e eficiente."

> "A API simula o sistema de catalogação de livros de uma pequena biblioteca comunitária. Ela permite organizar os livros disponíveis, consultar detalhes por ID, adicionar novos exemplares e remover títulos antigos. É indicada para uso em escolas, centros culturais ou projetos educacionais que necessitam de um controle básico e funcional de obras literárias."

---

## 👥 Integrantes da Dupla

- Calebe Andreatta de Oliveira - [cntoliveira](https://github.com/cntoliveira)
- Vitor Augusto Costa - [Vitor-vt](https://github.com/Vitor-vt)

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET 8)
- **Framework:** ASP.NET Core - Minimal API
- **ORM:** Entity Framework Core
- **Banco de Dados:** SQLite
- **Front-end:** JavaScript
- **Versionamento:** Git + GitHub

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download)
- [SQLite](https://www.sqlite.org/download.html) (ou algum cliente de visualização como DB Browser for SQLite)
- Git instalado

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/cntoliveira/biblioteca-de-livros

# 2. Acesse a pasta do projeto
cd BibliotecaApi

# 3. Restaure os pacotes
dotnet restore

# 4. Populando o Banco com Seed (Dados Iniciais)
# Para facilitar os testes, você pode popular o banco SQLite com dados iniciais usando o arquivo seed.sql.
# Passos para usar a seed:
# Certifique-se que a aplicação está parada.
# Execute o comando abaixo para importar os dados no banco:

sqlite3 biblioteca.db < livros.sql

# Após isso, rode a aplicação (dotnet run) e acesse o endpoint GET /livros para verificar os livros já cadastrados.

# 5. Execute a aplicação
dotnet run