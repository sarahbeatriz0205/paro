using Paro.Models;

namespace Paro.Repositories.RepositoryInterfaces
{
    public interface ISalaDao<Sala>
    {
        IEnumerable<Sala> Listar();
        Sala ObterPorId(int id);
        void CriarSala(Sala sala);
        void AlterarSala(Sala sala);
        void ExcluirSala(Sala sala);

    }
}
