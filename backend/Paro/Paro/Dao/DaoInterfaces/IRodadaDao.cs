using Paro.Entities;

namespace Paro.Dao.DaoInterfaces
{
    public interface IRodadaDao<Rodada>
    {
        IEnumerable<Rodada> Listar();
        Rodada ObterPorId(int id);
        void CriarRodada(Rodada rodada);
        void AlterarRodada(Rodada rodada);
        void ExcluirRodada(Rodada rodada);
    }
}
