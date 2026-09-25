using System.Collections.Generic;
using System.Linq;
using Paro.Utils;
using Paro.Entities;

namespace Paro.Services
{
    public class SalaService
    {
        private readonly Factory _factory;
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

        public void CriarSala(Sala sala)
        {
            var salaDao =_factory.ObterSalaDao();
            // organizador tem que ir pra sala?
            sala.Codigo = GerarCodigoSala();
            salaDao.CriarSala(sala);
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

        public Sala? AlterarSala(Sala sala)
        {
            var salaDao = _factory.ObterSalaDao();
            var salaBuscada = salaDao.ObterPorId(sala.Id);
            if (salaBuscada is null)
            {
                return null;
            }
            salaDao.AlterarSala(sala);
            return sala;
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
    }
}