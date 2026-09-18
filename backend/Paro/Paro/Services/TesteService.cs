using Paro.Models;

namespace Paro.Services
{
    public static class TesteService
    {
        static List<Teste> Testes { get; }
        static int nextId = 3;
        static TesteService()
        {
            Testes = new List<Teste>
        {
            new Teste { Id = 1, Name = "Teste 1", IsGlutenFree = false },
            new Teste { Id = 2, Name = "Teste 2", IsGlutenFree = true }
        };
        }

        public static List<Teste> GetAll() => Testes;

        public static Teste? Get(int id) => Testes.FirstOrDefault(t => t.Id == id);

        public static void Add(Teste teste)
        {
            teste.Id = nextId++;
            Testes.Add(teste);
        }

        public static void Delete(int id)
        {
            var teste = Get(id);
            if (teste is null)
                return;

            Testes.Remove(teste);
        }

        public static void Update(Teste teste)
        {
            var index = Testes.FindIndex(t => t.Id == teste.Id);
            if (index == -1)
                return;

            Testes[index] = teste;
        }
    }
}
