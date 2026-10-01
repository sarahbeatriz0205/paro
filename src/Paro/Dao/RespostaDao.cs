using Paro.Utils;
using Paro.Models;

namespace Paro.Dao
{
    public class RespostaDao
    {
        private readonly ContextDb _contexto;

        public RespostaDao(ContextDb contexto)
        {
            _contexto = contexto;
        }

        public void CriarResposta(Resposta resposta)
        {
            _contexto.Set<Resposta>().Add(resposta);
            _contexto.SaveChanges();
        }

        public List<Resposta> ListarRespostasPorRodada(int rodadaId)
        {
            return _contexto.Set<Resposta>().Where(r => r.IdRodada == rodadaId).ToList();
        }
    }
}
