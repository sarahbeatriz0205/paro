using Paro.Models;
using System.Collections.Generic;
using System.Linq;

namespace Paro.Services
{
    public static class SalaService
    {
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

        public static bool Validar(Sala sala)
        {
            if (sala is null)
            {
                return false;
            }
            return true;
        }

        public static Sala? Adicionar(Sala sala)
        {
            bool ehValido = SalaService.Validar(sala);
            if (!ehValido)
            {
                return null;
            }
            sala.Id = nextId++;
            Salas.Add(sala);
            return sala;
        }

        public static Sala? Excluir(int id)
        {
            var sala = ObterPorId(id);
            if (sala is null)
                return null;
            Salas.Remove(sala);
            return sala;
        }

        public static Sala? Alterar(Sala sala)
        {
            bool ehValido = SalaService.Validar(sala);
            if (!ehValido)
            {
                return null;
            }
            var index = Salas.FindIndex(t => t.Id == sala.Id);
            if (index == -1)
                return null;

            Salas[index] = sala;
            return sala;
        }

        public int GerarCodigoSala()
        {
            var random = new Random();
            int codigoSala = random.Next(10000, 99999);
        }
    }
}