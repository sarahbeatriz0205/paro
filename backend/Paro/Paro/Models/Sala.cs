namespace Paro.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public StatusEnum? Status { get; set; }
        public int QuantidadeRodadas { get; set; }
        public List<Jogador>? Jogadores { get; set; }
    }

    public class StatusEnum
    {
        public enum Status
        {
            NaoIniciada,
            EmAndamento,
            Finalizada
        }
    }
}