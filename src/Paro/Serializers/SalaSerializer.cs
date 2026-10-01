using Paro.Models;

namespace Paro.Serializers
{
    public class SalaSerializer
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public Sala.StatusEnum Status { get; set; }
        public int QuantidadeRodadas { get; set; }
        public List<Jogador> Jogadores { get; set; } = new List<Jogador>();
        public List<LinksHateoas> Links { get; set; } = new List<LinksHateoas>();
    }

    public class LinksHateoas
    {
        public string Rel { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
    }
}
