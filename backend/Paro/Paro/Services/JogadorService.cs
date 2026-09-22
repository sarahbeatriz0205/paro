using Paro.Models;
using Paro.Repositories;
using Paro.Repositories.RepositoryInterfaces;

namespace Paro.Services
{
    public class JogadorService
    {
        private readonly IRepository<Jogador>? _jogadorRepository;
        public JogadorService(IRepository<Jogador>? jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }
        public IEnumerable<Jogador> Listar()
        {
            return _jogadorRepository.Listar();
        }   
        public Jogador? ObterPorId(int id)
        {
            return _jogadorRepository.ObterPorId(id);
        }
        public List<string> Validar(Jogador jogador)
        {
            var erros = new List<string>();

            if (jogador is null)
            {
                erros.Add("Jogador não pode ser nulo.");
                return erros;
            }

            if (string.IsNullOrWhiteSpace(jogador.Nome))
                erros.Add("Nome do jogador é obrigatório.");

            if (jogador.PontuacaoTotal < 0)
                erros.Add("Pontuação total não pode ser negativa.");

            return erros;
        }

        public void Adicionar(Jogador jogador)
        {
            var ehValido = Validar(jogador);
            if (ehValido.Any())
                throw new ArgumentException(string.Join(", ", ehValido));
            _jogadorRepository.Adicionar(jogador);
        }

        public void Excluir(Jogador jogador)
        {
            var ehValido = Validar(jogador);
            if (ehValido.Any())
                throw new ArgumentException(string.Join(", ", ehValido));
            _jogadorRepository.Excluir(jogador);
        }

        public void Alterar(Jogador jogador)
        {
            var ehValido = Validar(jogador);
            if (ehValido.Any())
                throw new ArgumentException(string.Join(", ", ehValido));
            _jogadorRepository.Alterar(jogador);
        }
    }
}
     