using Paro.Models;

namespace Paro.Services
{
    public static class JogadorService
    {
        static List<Jogador> Jogadores { get; } = new List<Jogador>();
        static int nextId = 1;
        public static List<Jogador> Listar() => Jogadores;

        public static Jogador? ObterPorId(int id)
        {
            var jogador = Jogadores.FirstOrDefault(t => t.Id == id);
            if (jogador is null)
            {
                return null;
            }
            return jogador;
        }
        public static bool Validar(Jogador jogador)
        {
            if (jogador is null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(jogador.Nome))
            {
                return false;
            }
            if (jogador.PontuacaoTotal < 0) {
                return false;
            }
            return true;
        }

        public static Jogador? Adicionar(Jogador jogador)
        {
            bool ehValido = JogadorService.Validar(jogador);
            if (!ehValido)
            {
                return null;
            }
            jogador.Id = nextId++;
            Jogadores.Add(jogador);
            return jogador;
        }

        public static Jogador? Excluir(int id)
        {
            var jogador = ObterPorId(id);
            if (jogador is null)
                return null;
            Jogadores.Remove(jogador);
            return jogador;
        }

        public static Jogador? Alterar(Jogador jogador)
        {
            bool ehValido = JogadorService.Validar(jogador);
            if (!ehValido)
            {
                return null;
            }
            var index = Jogadores.FindIndex(t => t.Id == jogador.Id);
            if (index == -1)
                return null;

            Jogadores[index] = jogador;
            return jogador;
        }
    }
}
