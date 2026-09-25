using Paro.Models;
using Paro.Utils;
using Paro.Dao.DaoInterfaces;
using Paro.Entities;

namespace Paro.Dao
{
    public class RodadaDao: IRodadaDao<Rodada> 
    {
        private readonly ContextDb _contexto;

        public RodadaDao(ContextDb contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Rodada> Listar()
        {
            return _contexto.Set<Rodada>().ToList();
        }
        public Rodada ObterPorId(int id)
        {
            return _contexto.Set<Rodada>().Find(id);
        }

        public void CriarRodada(Rodada rodada)
        {
            _contexto.Set<Rodada>().Add(rodada);
            _contexto.SaveChanges();
        }

        public void AlterarRodada(Rodada rodada)
        {
            _contexto.Set<Rodada>().Update(rodada);
            _contexto.SaveChanges();
        }

        public void ExcluirRodada(Rodada rodada)
        {
            _contexto.Set<Rodada>().Remove(rodada);
            _contexto.SaveChanges();
        }
    }
}
