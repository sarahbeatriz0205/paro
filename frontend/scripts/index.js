document.getElementById('btnEntrarSala').addEventListener('click', () => {
    const apelido = document.getElementById('nickname').value.trim();

    if (!apelido) {
        alert('Digite um apelido antes de continuar.');
        return;
    }

    localStorage.setItem('nickname', apelido); 
    window.location.href = 'entrar-sala.html';
});