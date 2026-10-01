using Paro.Models;

namespace Paro.Repositories.RepositoryInterfaces
{
    public interface IJogadorDao<Jogador>
    {
        IEnumerable<Jogador> Listar();
        Jogador ObterPorId(int id);
        void CriarJogador(Jogador jogador);
        void AlterarJogador(Jogador jogador);
        void ExcluirJogador(Jogador jogador);

    }
}
