using System;

namespace Paro.Models
{
    public class Jogador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int PontuacaoTotal { get; set; }
        public Boolean IdentificaOrganizador { get; set; } // um jogador também pode ser organizador
    }
}
