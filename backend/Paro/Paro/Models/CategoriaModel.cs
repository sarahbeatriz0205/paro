using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Categorias")]
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
