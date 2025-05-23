using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Models;

// Classe responsável pela configuração do contexto do banco de dados usando Entity Framework Core
// Herdando de DbContext para representar a sessão com o banco de dados
namespace BibliotecaApi.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que recebe opções de configuração e as passa para a classe base DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Propriedade que representa a tabela "Livros" no banco de dados
        // Permite realizar operações CRUD nessa tabela
        public DbSet<Livro> Livros { get; set; }
    }
}
