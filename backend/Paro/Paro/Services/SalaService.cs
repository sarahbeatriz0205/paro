using Paro.Models;
using System.Collections.Generic;
using System.Linq;
using Paro.Utils;

namespace Paro.Services
{
    public static class SalaService
    {
        private readonly ContextDb _contexto;
        static List<Sala> Salas { get; } = new List<Sala>();
        static int nextId = 0;

        public static Sala? ObterPorId(int id)
        {
            var sala = Salas.FirstOrDefault(t => t.Id == id);
            if (sala is null)
            {
                return null;
            }
            return sala;
        }

        public static Sala? CriarSala(Sala sala)
        {
            // organizador tem que ir pra sala?
            sala.Codigo = GerarCodigoSala();
            _contexto.Salas.Add(sala);
            return sala;
        }

        public static Sala? ExcluirSala(int id)
        {
            var sala = ObterPorId(id);
            if (sala is null)
                return null;
            _contexto.Salas.Remove(sala);
            return sala;
        }

        public static Sala? AlterarSala(Sala sala)
        {
            var sala = ObterPorId(id);
            if (sala is null)
                return null;
            _contexto.Salas.Insert(sala, sala);
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
            Sala sala = ObterPorId(idSala);
            if (sala is null || !sala.Ativa)
            {
                return;
            }
            _contexto.Jogadores.Add(jogador);
            sala.Jogadores.Add(jogador);
            return jogador;
        }
    }
}