using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paro.Models
{
    [Table("Jogadores")]
    public class JogadorModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int PontuacaoTotal { get; set; }
        public bool IdentificaOrganizador { get; set; } // um jogador também pode ser organizador
    }
}