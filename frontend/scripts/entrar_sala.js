document.querySelector('.back-btn').addEventListener('click', () => {
    window.history.back();
});


async function entrarNaSala() {
    const url = 'http://localhost:5288/sala/entrar';

    var codigo = document.getElementById('codigoSala').value;
    var nomeJogador = localStorage.getItem('nickname');

    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ codigo: parseInt(codigo), nomeJogador: nomeJogador })
    });

    const jogadorEntrou = await response.json();

    localStorage.setItem('salaId', jogadorEntrou.salaId); 
    localStorage.setItem('souOrganizador', 'false');
    window.location.href = 'menu_sala.html';
}

document.getElementById('btnEntrar').addEventListener('click', entrarNaSala);