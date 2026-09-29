using Paro.Dao;
using Paro.Models;
using Paro.Requests.RespostaRequests;
namespace Paro.Services
{
    public class RespostaService
    {
        private readonly Factory _factory;
        public RespostaService(Factory factory)
        {
            _factory = factory;
        }

        public int CalculaPontuacao(string? resposta, char letra)
        {
            if (string.IsNullOrWhiteSpace(resposta))
            {
                return 0;
            }

            var respostaLimpa = resposta.Trim();

            if (char.ToUpper(respostaLimpa[0]) != char.ToUpper(letra)) 
            {
                return 0;
            }

            return 10;
        }

        public Resposta? CriarResposta(EnviarRespostaRequest request)
        {
            var respostaDao = _factory.ObterRespostaDao();
            var rodadaService = _factory.ObterRodadaService();
            var rodada = rodadaService.ObterRodadaPorId(request.IdRodada);

            if (rodada is null || rodada.Finalizada)
            {
                return null;
            }

            var resposta = new Resposta
            {
                IdRodada = request.IdRodada,
                IdJogador = request.IdJogador,
                IdCategoria = request.IdCategoria,
                RespostaTexto = request.RespostaTexto,
                Pontuacao = CalculaPontuacao(request.RespostaTexto, rodada.Letra)
            };

            respostaDao.CriarResposta(resposta);
            return resposta;
        }
    }
}

