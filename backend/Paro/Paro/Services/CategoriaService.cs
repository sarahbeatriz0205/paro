using Paro.Models;

namespace Paro.Services
{
    public class CategoriaService
    {
        private readonly Factory _factory;
        public CategoriaService(Factory factory)
        {
            _factory = factory;
        }
        public List<Categoria> ListaDeCategorias()
        {
            var categoriaDao = _factory.ObterCategoriaDao();
            return categoriaDao.Listar();
        }
    }
}
