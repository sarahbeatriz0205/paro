using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Salas")]
    public class SalaModel
    {
        public int Id { get; set; }

        // id da rodada nao vai mudar até a sala acabar, o que vai mudar sao as configs da rodada
        // id pra a sala ter acesso as configs da rodada (tempo e letra)
        // LEMBRE DE FAZER A MIGRAÇÃO -> dotnet ef migrations add AddIdRodadaEmSala / dotnet ef database update
        public int IdRodada { get; set; } 
        public int Codigo { get; set; }
        public StatusEnum? Status { get; set; }
        public int QuantidadeRodadas { get; set; }
        public List<JogadorModel>? Jogadores { get; set; }

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