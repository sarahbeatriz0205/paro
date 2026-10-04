const salaId = localStorage.getItem('salaId');
const souOrganizador = localStorage.getItem('souOrganizador') === 'true';

const cores = ['cyan', 'yellow', 'red'];

async function atualizarSala() {
    try {
        const response = await fetch(`http://192.168.1.79:5288/sala/${salaId}`);
        const textoCru = await response.text(); // pega o texto bruto primeiro

        console.log('STATUS:', response.status);
        console.log('CORPO CRU:', textoCru);

        const sala = JSON.parse(textoCru); // só depois tenta parsear

        document.getElementById('codigoSala').textContent = sala.codigo;
        renderizarJogadores(sala.jogadores);
        document.getElementById('btnIniciar').style.display = souOrganizador ? 'flex' : 'none';

    } catch (erro) {
        console.error('ERRO NO POLLING:', erro);
    }
}

function renderizarJogadores(jogadores) {
    const grid = document.querySelector('.players-grid');
    grid.innerHTML = '';

    jogadores.forEach((j, index) => {
        const cor = cores[index % cores.length];
        const inicial = j.nome.charAt(0).toUpperCase();

        const item = document.createElement('div');
        item.className = 'player-item';
        item.innerHTML = `
            <div class="player-left">
                <div class="avatar-circle ${cor}">${inicial}</div>
                <span class="player-name">${j.nome}</span>
            </div>
            ${j.identificaOrganizador ? `
                <div class="crown-icon" title="Anfitrião">
                    <svg width="20" height="20" fill="currentColor" viewBox="0 0 24 24">
                        <path d="M5 16L3 5l5.5 5L12 4l3.5 6L21 5l-2 11H5zm14 3c0 .6-.4 1-1 1H6c-.6 0-1-.4-1-1v-1h14v1z"/>
                    </svg>
                </div>
            ` : ''}
        `;
        grid.appendChild(item);
    });
}

atualizarSala();
setInterval(atualizarSala, 2000);