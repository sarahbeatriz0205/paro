namespace Paro.Entities
{
    public class Jogador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int PontuacaoTotal { get; set; }
        public bool IdentificaOrganizador { get; set; }

        public Jogador(string? nome, int pontuacaoTotal, bool identificaOrganizador)
        {
            Id = 0; 
            Nome = nome;
            PontuacaoTotal = pontuacaoTotal;
            IdentificaOrganizador = identificaOrganizador;
        }
}
}
