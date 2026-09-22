using Paro.Models;

namespace Paro.Repositories.RepositoryInterfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Listar();
        T ObterPorId(int id);
        void Adicionar(T entity);
        void Alterar(T entity);
        void Excluir(T entity);

    }
}
