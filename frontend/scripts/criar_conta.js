async function criarConta() {
    const url = 'http://192.168.1.79:5288/auth/criar';

    var nome = document.getElementById('nickname').value;
    var senha = document.getElementById('password').value;

    await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nome: nome, senha: senha })
    });

    window.location.href = 'login.html';
}

document.getElementById('btnCriarConta').addEventListener('click', criarConta);