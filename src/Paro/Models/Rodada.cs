using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Rodadas")]
    public class Rodada
    {
        public int Id { get; set; }
        public int Tempo { get; set; }
        public char Letra { get; set; }
        public int NumeroRodada { get; set; }
        public bool Finalizada { get; set; } = false;
        public List<Categoria>? Categorias { get; set; }
    }
}