using Paro.Models;
using Paro.Requests.SalaRequests;

namespace Paro.Services
{
    public class SalaService
    {
        private readonly Factory _factory;
        private List<Jogador> jogadores = new List<Jogador>();
        public SalaService(Factory factory)
        {
            _factory = factory;
        }
        public Sala? ObterSalaPorId(int id)
        {
            var salaDao = _factory.ObterSalaDao();
            var busca = salaDao.ObterPorId(id);
            if (busca is null)
            {
                return null;
            }
            return busca;
        }

        public Sala CriarSala(CriarSalaRequest salaRequest)
        {
            Sala sala = new Sala
            {
                QuantidadeRodadas = salaRequest.QuantidadeRodadas,
                Status = Sala.StatusEnum.NaoIniciada,
                Codigo = GerarCodigoSala(),
            };

            Jogador organizador = new Jogador
            {
                Nome = salaRequest.NomeOrganizador,
                PontuacaoTotal = 0,
                IdentificaOrganizador = true

            };

            var salaDao = _factory.ObterSalaDao();
            salaDao.InserirJogadorNaSala(organizador, sala);
            salaDao.CriarSala(sala);
            return sala;
        }

        public Sala? ExcluirSala(int id)
        {
            var salaDao = _factory.ObterSalaDao();
            var sala = salaDao.ObterPorId(id);
            if (sala is null)
            {
                return null;
            }
            salaDao.ExcluirSala(sala);
            return sala;
        }

        public Sala? AlterarSala(int id, AlterarSalaRequest sala)
        {
            var salaDao = _factory.ObterSalaDao();
            var salaBuscada = salaDao.ObterPorId(id);
            if (salaBuscada is null)
            {
                return null;
            }
            salaBuscada.QuantidadeRodadas = sala.QuantidadeRodadas;
            salaDao.AlterarSala(salaBuscada);
            return salaBuscada;
        }

        public static int GerarCodigoSala()
        {
            var random = new Random();
            int codigoSala = random.Next(100000, 999999);
            return codigoSala;
        }

        public Jogador InserirJogadorNaSala(Jogador jogador, int idSala)
        {
            var salaDao = _factory.ObterSalaDao();
            var sala = salaDao.ObterPorId(idSala);
            if (sala is null || !sala.Ativa)
            {
                return null;
            }
            salaDao.InserirJogadorNaSala(jogador, sala);
            return jogador;
        }

        public bool IniciarSala()
        {
            // ainda nao sei como eu faço
            return false;
        }

        public Jogador EntrarNaSala(string jogador, int codigo)
        {
            // por meio do código da sala o jogador consegue entrar

            var salaDao = _factory.ObterSalaDao();
            Sala salaBuscada = salaDao.BuscarSalaPorCodigo(codigo);
            Jogador jogadorCriado = new Jogador
            {
                Nome = jogador,
                PontuacaoTotal = 0,
                IdentificaOrganizador = false
            };

            if (salaBuscada.Ativa)
            {
                salaDao.InserirJogadorNaSala(jogadorCriado, salaBuscada);
            }
            return jogadorCriado;
        }
    }
}