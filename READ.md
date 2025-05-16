# Biblioteca API

API REST minimalista para gerenciamento de livros, desenvolvida em C# com .NET 8, utilizando Entity Framework Core e banco de dados SQLite.

## 🔧 Tecnologias

- .NET 8 (Minimal API)
- Entity Framework Core
- SQLite

## 🚀 Como executar o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/cntoliveira/biblioteca-de-livros.git
   cd biblioteca-de-livros
   ```

2. Restaure os pacotes:
   ```bash
   dotnet restore
   ```

3. Crie o banco de dados e adicione os dados iniciais:

   - Crie o banco com as tabelas:
     ```bash
     dotnet ef database update
     ```

   - Popule o banco com os dados usando o arquivo `seed.sql`:
     ```bash
     sqlite3 biblioteca.db < seed.sql
     ```

   > O arquivo `seed.sql` já está incluso no repositório, localizado na raiz do projeto.

4. Execute o projeto:
   ```bash
   dotnet run
   ```

5. Acesse as rotas da API:

   - `GET /livros` → Lista todos os livros
   - `GET /livros/{id}` → Busca um livro por ID
   - `POST /livros` → Cadastra um novo livro
   - `PUT /livros/{id}` → Atualiza os dados de um livro
   - `DELETE /livros/{id}` → Remove um livro

## 📁 Estrutura

- `Program.cs`: Arquivo principal com as rotas da API
- `AppDbContext.cs`: Configuração do banco de dados
- `Livro.cs`: Modelo de entidade
- `livros.sql`: Dados iniciais para popular o banco SQLite

## 📝 Observações

- As pastas `bin/`, `obj/` e arquivos temporários são ignorados via `.gitignore`.
- Todas as rotas da API estão comentadas no código.
- A API segue o padrão REST.

---

Desenvolvido como parte do projeto acadêmico de API RESTful.
