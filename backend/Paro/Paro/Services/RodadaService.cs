using Paro.Models;
using System.Collections.Generic;

namespace Paro.Services
{
    public static class RodadaService
    {
        static List<Rodada> Rodadas { get; } = new List<Rodada>();
        static int nextId = 0;

        public static Rodada? ObterPorId(int id)
        {
            var rodada = Rodadas.FirstOrDefault(t => t.Id == id);
            if (rodada is null)
            {
                return null;
            }
            return rodada;
        }
        public static bool Validar(Rodada rodada)
        {
            if (rodada is null)
            {
                return false;
            }
            if (rodada.Tempo < 0)
            {
                return false;
            }
            return true;
        }

        public static Rodada? Adicionar(Rodada rodada)
        {
            bool ehValido = RodadaService.Validar(rodada);
            if (!ehValido)
            {
                return null;
            }
            rodada.Id = nextId++;
            Rodadas.Add(rodada);
            return rodada;
        }

        public static Rodada? Excluir(int id)
        {
            var rodada = ObterPorId(id);
            if (rodada is null)
                return null;
            Rodadas.Remove(rodada);
            return rodada;
        }

        public static Rodada? Alterar(Rodada rodada)
        {
            bool ehValido = RodadaService.Validar(rodada);
            if (!ehValido)
            {
                return null;
            }
            var index = Rodadas.FindIndex(t => t.Id == rodada.Id);
            if (index == -1)
                return null;

            Rodadas[index] = rodada;
            return rodada;
        }
    }
}
