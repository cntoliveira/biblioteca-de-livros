using BibliotecaApi.Data;
using BibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura CORS para permitir requisições de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configura Entity Framework para usar SQLite com o banco 'biblioteca.db'
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

// Adiciona serviços para documentação Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita CORS no app
app.UseCors();

// Ativa middleware do Swagger para documentação interativa
app.UseSwagger();
app.UseSwaggerUI();

// Redireciona requisições HTTP para HTTPS
app.UseHttpsRedirection();

// Rota de teste para verificar se a API está funcionando
app.MapGet("/", () => "API da Biblioteca está rodando!");

// Retorna a lista completa de livros cadastrados
app.MapGet("/livros", async (AppDbContext db) =>
    await db.Livros.ToListAsync());

// Busca um livro pelo ID, retorna 404 se não encontrado
app.MapGet("/livros/{id}", async (int id, AppDbContext db) =>
    await db.Livros.FindAsync(id) is Livro livro
        ? Results.Ok(livro)
        : Results.NotFound("Livro não encontrado!"));

// Cria um novo livro, com validação para campos obrigatórios
app.MapPost("/livros", async (Livro livro, AppDbContext db) =>
{
    if (string.IsNullOrEmpty(livro.Titulo) || string.IsNullOrEmpty(livro.Autor))
    {
        return Results.BadRequest("Título e Autor são obrigatórios!");
    }

    db.Livros.Add(livro);
    await db.SaveChangesAsync();
    return Results.Created($"/livros/{livro.Id}", livro);
});

// Atualiza um livro existente pelo ID, com validação e retorno 404 se não existir
app.MapPut("/livros/{id}", async (int id, Livro inputLivro, AppDbContext db) =>
{
    if (string.IsNullOrEmpty(inputLivro.Titulo) || string.IsNullOrEmpty(inputLivro.Autor))
    {
        return Results.BadRequest("Título e Autor são obrigatórios!");
    }

    var livro = await db.Livros.FindAsync(id);
    if (livro is null) return Results.NotFound("Livro não encontrado!");

    livro.Titulo = inputLivro.Titulo;
    livro.Autor = inputLivro.Autor;
    livro.Genero = inputLivro.Genero;
    livro.AnoPublicacao = inputLivro.AnoPublicacao;

    await db.SaveChangesAsync();
    return Results.Ok(livro);
});

// Deleta um livro pelo ID, retorna 404 se não encontrado
app.MapDelete("/livros/{id}", async (int id, AppDbContext db) =>
{
    var livro = await db.Livros.FindAsync(id);
    if (livro is null) return Results.NotFound("Livro não encontrado!");

    db.Livros.Remove(livro);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();