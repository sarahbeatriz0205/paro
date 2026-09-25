using Paro.Entities;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Paro.Services
{
    public class RodadaService
    {
        private readonly Factory _factory;

        public RodadaService(Factory factory)
        {
            _factory = factory;
        }

        // cronômetro vai ter que ser em javascript direto no front
        // back vai retornar o tempo que o usuário setou pra a rodada

        public List<Rodada> RodadasPreConfiguradas(int salaId, int tempo, int qtdRodadas)
        {
            List<Rodada> rodadas = new List<Rodada>();
            int limite = qtdRodadas + 1;
            Rodada rodada;
            while (qtdRodadas < limite)
            {
                rodada = new Rodada(tempo, SorteiaLetra());
                rodadas.Add(rodada);
            }
            return rodadas;
        }

        public char SorteiaLetra()
        {
            List<char> alfabeto = new List<char> {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };
            Random random = new Random();
            return alfabeto[random.Next(alfabeto.Count)]; // índice aleatório
        }

        public Rodada ObterRodadaPorId(int id)
        {
            var rodadaDao = _factory.ObterRodadaDao();
            var busca = rodadaDao.ObterPorId(id);
            if (busca is null)
            {
                return null;
            }
            return busca;
        }
    }
}
