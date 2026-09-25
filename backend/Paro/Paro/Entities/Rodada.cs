namespace Paro.Entities
{
    public class Rodada
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public int Tempo { get; set; }
        public char Letra { get; set; }

        public Rodada(int tempo, char letra)
        {
            Id = 0; // verificar se a ORM realmente muda isso
            Tempo = tempo;
            Letra = letra;
        }
    }
}
