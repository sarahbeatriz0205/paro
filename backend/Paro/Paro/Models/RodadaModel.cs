using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Rodadas")]
    public class RodadaModel
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public int Tempo { get; set; }
        public char Letra { get; set; }
    }
}