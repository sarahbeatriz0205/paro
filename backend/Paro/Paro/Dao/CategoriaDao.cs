using Paro.Utils;
using Paro.Models;

namespace Paro.Dao
{
    public class CategoriaDao
    {
        private readonly ContextDb _contexto;

        public CategoriaDao(ContextDb contexto)
        {
            _contexto = contexto;
        }

        public List<Categoria> Listar()
        {
            return _contexto.Set<Categoria>().ToList();
        }
    }
}
