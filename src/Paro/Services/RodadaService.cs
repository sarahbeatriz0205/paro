using Paro.Models;
using Paro.Repositories;
using Paro.Utils;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

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

        public List<Rodada> RodadasPreConfiguradas(int quantidadeRodadas, int tempo)
        {
            List<Rodada> rodadas = new List<Rodada>();
            Rodada rodada;

            for (int i = 0; i < quantidadeRodadas; i++)
            {
                rodada = new Rodada { Tempo = tempo, 
                                      Letra = SorteiaLetra(), 
                                      NumeroRodada = i + 1 , 
                                      Categorias = _factory.ObterCategoriaService().ListaDeCategorias() };
                rodadas.Add(rodada);
            }
 
            return rodadas;
        }

        private char SorteiaLetra()
        {
            List<char> alfabeto = new List<char> {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'x', 'z'
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


        public Rodada? FinalizarRodada(int rodadaId)
        {
            var rodadaDao = _factory.ObterRodadaDao();
            var rodada = rodadaDao.ObterPorId(rodadaId);

            if (rodada is null || rodada.Finalizada)
            {
                return null;
            }

            rodada.Finalizada = true;
            rodadaDao.AlterarRodada(rodada);

            return rodada;
        }

    }
}
