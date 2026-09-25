using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Placares")]
    public class PlacarModel
    {
        public List<int>? Pontuacoes { get; set; }
        public List<JogadorModel>? Jogadores { get; set; }
    }
}
