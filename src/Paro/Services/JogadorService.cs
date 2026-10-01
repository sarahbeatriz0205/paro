using Paro.Models;

namespace Paro.Services
{
    public class JogadorService
    {
        private readonly Factory _factory;
        public JogadorService(Factory factory)
        {
            _factory = factory;
        }
        public IEnumerable<Jogador> Listar()
        {
            var jogadorDao = _factory.ObterJogadorDao();
            return jogadorDao.Listar();
        }
        public Jogador? ObterPorId(int id)
        {
            var jogadorDao = _factory.ObterJogadorDao();
            var busca = jogadorDao.ObterPorId(id);
            if (busca is null)
            {
                return null;
            }
            return busca;
        }

        public void CriarJogador(Jogador jogador)
        {
            var jogadorDao = _factory.ObterJogadorDao();
            jogadorDao.CriarJogador(jogador);
        }

        public void ExcluirJogador(Jogador jogador)
        {
            var jogadorDao = _factory.ObterJogadorDao();
            jogadorDao.ExcluirJogador(jogador);
        }

        public void AlterarJogador(Jogador jogador)
        {
            var jogadorDao = _factory.ObterJogadorDao();
            jogadorDao.AlterarJogador(jogador);
        }
    }
}
     