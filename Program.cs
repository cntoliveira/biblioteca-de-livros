using BibliotecaApi.Data;
using BibliotecaApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar e configurar CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Configurar o Entity Framework com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));

// Adicionar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar CORS
app.UseCors();

// Usar Swagger para documentação da API
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Rota de teste para confirmar se a API está funcionando
app.MapGet("/", () => "API da Biblioteca está rodando!");

// Listar todos os livros
app.MapGet("/livros", async (AppDbContext db) =>
    await db.Livros.ToListAsync());

// Buscar livro por ID
app.MapGet("/livros/{id}", async (int id, AppDbContext db) =>
    await db.Livros.FindAsync(id) is Livro livro
        ? Results.Ok(livro)
        : Results.NotFound("Livro não encontrado!"));

// Criar novo livro
app.MapPost("/livros", async (Livro livro, AppDbContext db) =>
{
    db.Livros.Add(livro);
    await db.SaveChangesAsync();
    return Results.Created($"/livros/{livro.Id}", livro);
});

// Atualizar livro
app.MapPut("/livros/{id}", async (int id, Livro inputLivro, AppDbContext db) =>
{
    var livro = await db.Livros.FindAsync(id);
    if (livro is null) return Results.NotFound("Livro não encontrado!");

    livro.Titulo = inputLivro.Titulo;
    livro.Autor = inputLivro.Autor;
    livro.Genero = inputLivro.Genero;
    livro.AnoPublicacao = inputLivro.AnoPublicacao;

    await db.SaveChangesAsync();
    return Results.Ok(livro);
});

// Deletar livro
app.MapDelete("/livros/{id}", async (int id, AppDbContext db) =>
{
    var livro = await db.Livros.FindAsync(id);
    if (livro is null) return Results.NotFound("Livro não encontrado!");

    db.Livros.Remove(livro);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();