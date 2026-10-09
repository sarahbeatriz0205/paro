document.querySelector('.back-btn').addEventListener('click', () => {
    window.history.back();
});


async function fazerLogin() {
    const url = 'http://localhost:5288/auth/login';

    var nome = document.getElementById('nickname').value;
    var senha = document.getElementById('password').value;

    var response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nome: nome, senha: senha })
    });

    const data = await response.json(); 

    localStorage.setItem('token', data.token);

    window.location.href = 'index.html';
}

document.getElementById('btnFazerLogin').addEventListener('click', fazerLogin);