using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Salas")]
    public class Sala
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public StatusEnum? Status { get; set; }
        public int QuantidadeRodadas { get; set; }
        public List<Jogador>? Jogadores { get; set; } = new();
        public List<Rodada> Rodadas { get; set; } = new(); 

        // se o status for "finalizada", a sala não está mais ativa
        public bool Ativa
        {
            get
            {
                if (Status == StatusEnum.Finalizada)
                {
                    return false;
                }
                return true;
            }
        }

        public enum StatusEnum
        {
            NaoIniciada,
            EmAndamento,
            Finalizada
        }
    }
}