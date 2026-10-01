namespace Paro.Models
{
    public class Resposta
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public int IdRodada { get; set; }
        public int IdJogador { get; set; }
        public int IdCategoria { get; set; }
        public string? RespostaTexto { get; set; } // pode vim nulo se o jogador for burro pra nao responder :)
        public int Pontuacao { get; set; } 

        // se a resposta não vier vazia o mano já ganha 10 pontos pq pra validar isso é lascado
        // se nao responder, 0 pontos

    }
}
