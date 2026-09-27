using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Placares")]
    public class Placar
    {
        public List<int>? Pontuacoes { get; set; }
        public List<Jogador>? Jogadores { get; set; }
    }
}
