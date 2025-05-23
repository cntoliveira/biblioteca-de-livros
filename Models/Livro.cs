// Representa o modelo de dados para um livro na biblioteca
namespace BibliotecaApi.Models
{
    public class Livro
    {
        // Identificador único do livro
        public int Id { get; set; }

        // Título do livro
        public string Titulo { get; set; }

        // Nome do autor do livro
        public string Autor { get; set; }

        // Gênero literário do livro (ex: Ficção, Romance, etc.)
        public string Genero { get; set; }

        // Ano de publicação do livro
        public int AnoPublicacao { get; set; }
    }
}
