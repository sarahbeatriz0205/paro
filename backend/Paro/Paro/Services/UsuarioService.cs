using Paro.Models;
using Paro.Requests.SalaRequests;

namespace Paro.Services
{
    public class UsuarioService
    {
        private readonly Factory _factory;
        private List<Jogador> jogadores = new List<Jogador>();
        public SalaService(Factory factory)
        {
            _factory = factory;
        }
    }
}