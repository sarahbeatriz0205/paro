namespace Paro.Requests.RespostaRequests
{
    public class EnviarRespostaRequest
    {
        public string? RespostaTexto { get; set; } 
        public int IdCategoria { get; set; }
        public int IdJogador { get; set; }
        public int IdRodada { get; set; }
    }
}
