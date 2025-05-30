const listaLivros = document.getElementById('lista-livros');
const btnGetTodos = document.getElementById('btn-todos');
const inputIdBusca = document.getElementById('input-id-busca');
const formBuscaId = document.getElementById('form-busca-id');
const inputTituloNovo = document.getElementById('input-titulo-novo');
const inputAutorNovo = document.getElementById('input-autor-novo');
const inputGeneroNovo = document.getElementById('input-genero-novo');
const inputAnoNovo = document.getElementById('input-ano-novo');
const formPost = document.getElementById('form-post');
const formPut = document.getElementById('form-put');
const formDelete = document.getElementById('form-delete');

const apiURL = 'http://localhost:5295/livros';

const getLivros = async() => {
    listaLivros.innerHTML = '';

    try {
        const response = await fetch(apiURL);
        if (!response.ok) throw new Error('Erro ao buscar os livros!');
        const livros = await response.json();

        livros.forEach(livro => {
            const li = document.createElement('li');
            li.innerText = `ID: ${livro.id} | Título: ${livro.titulo} | Autor: ${livro.autor}`;
            listaLivros.appendChild(li);
        });

    } catch (error) {
        console.log(error.message);
        listaLivros.innerText = error.message;
    }
};

const getLivroPorId = async(id) => {
    listaLivros.innerHTML = '';

    try {
        const response = await fetch(`${apiURL}/${id}`);
        if (!response.ok) throw new Error('Livro não encontrado!');
        const livro = await response.json();

        const li = document.createElement('li');
        li.innerText = `ID: ${livro.id} | Título: ${livro.titulo} | Autor: ${livro.autor}`;
        listaLivros.appendChild(li);

    } catch (error) {
        console.log(error.message);
        listaLivros.innerText = error.message;
        alert(error.message);
    }
};

const postLivro = async(novoLivro) => {
    listaLivros.innerHTML = '';

    try {
        const response = await fetch(apiURL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(novoLivro)
        });
        if (!response.ok) throw new Error('Erro ao adicionar o livro!');
        const livro = await response.json();

        alert(`O livro "${livro.titulo}" foi adicionado com sucesso!`);
        getLivros(); // Atualiza a lista após adicionar

    } catch (error) {
        console.log(error.message);
        alert(error.message);
    }
};

const putLivro = async() => {
    const id = document.getElementById('input-id-update').value;
    const titulo = document.getElementById('input-titulo-update').value;
    const autor = document.getElementById('input-autor-update').value;

    listaLivros.innerHTML = '';

    try {
        const response = await fetch(`${apiURL}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ titulo, autor })
        });
        if (!response.ok) throw new Error('Erro ao atualizar o livro!');
        const livro = await response.json();

        alert(`O livro "${livro.titulo}" foi atualizado com sucesso!`);
        getLivros();

    } catch (error) {
        console.log(error.message);
        alert(error.message);
    }
};

const deleteLivro = async() => {
    const id = document.getElementById('input-id-delete').value;
    listaLivros.innerHTML = '';

    try {
        const response = await fetch(`${apiURL}/${id}`, {
            method: 'DELETE'
        });
        if (!response.ok) throw new Error('Erro ao deletar o livro!');
        const resultado = await response.text();

        alert(resultado);
        getLivros();

    } catch (error) {
        alert(error.message);
    }
};

// Eventos
btnGetTodos.addEventListener('click', e => {
    e.preventDefault();
    getLivros();
});

formBuscaId.addEventListener('submit', e => {
    e.preventDefault();
    getLivroPorId(inputIdBusca.value);
});

formPost.addEventListener('submit', e => {
    e.preventDefault();
    postLivro({
        titulo: inputTituloNovo.value,
        autor: inputAutorNovo.value,
        genero: inputGeneroNovo.value,
        anoPublicacao: parseInt(inputAnoNovo.value)
    });
});

formPut.addEventListener('submit', e => {
    e.preventDefault();
    putLivro();
});

formDelete.addEventListener('submit', e => {
    e.preventDefault();
    deleteLivro();
});