document.querySelector('.back-btn').addEventListener('click', () => {
    window.history.back();
});

async function criarSala() {
    const url = 'http://192.168.1.79:5288/sala/criar-sala';

    const token = localStorage.getItem('token'); 

    if (!token) {
        window.location.href = 'login.html'; 
        return;
    }

    var quantidadeRodadas = document.getElementById('quantidade-rodadas').value;
    var tempo = document.getElementById('tempo').value;

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token 
        },
        body: JSON.stringify({ quantidadeRodadas: parseInt(quantidadeRodadas),  tempo: parseInt(tempo)})
    });

    if (response.status === 401) {
        localStorage.removeItem('token'); 
        window.location.href = 'login.html';
        return;
    }
    else {
        const sala = await response.json();
        console.log('SALA RECEBIDA:', sala);
        localStorage.setItem('salaId', sala.id);
        localStorage.setItem('souOrganizador', 'true');
        window.location.href = 'menu_sala.html';
    }

}

document.getElementById('btnCriarSala').addEventListener('click', criarSala)