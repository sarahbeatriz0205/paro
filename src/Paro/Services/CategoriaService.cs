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
        private static readonly string[] NomesPadrao =
        { "Nome", "Fruta", "Animal", "Objeto", "Cor", "Comida" }; 

        public List<Categoria> ListaDeCategorias() =>
        NomesPadrao.Select(n => new Categoria { Nome = n }).ToList();
    }
}
