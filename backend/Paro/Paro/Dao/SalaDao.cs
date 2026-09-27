using Microsoft.EntityFrameworkCore;
using Paro.Models;
using Paro.Repositories.RepositoryInterfaces;

namespace Paro.Repositories
{
    public class SalaDao : ISalaDao<Sala>
    {
        private readonly DbContext _contexto;

        public SalaDao(DbContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Sala> Listar()
        {
            return _contexto.Set<Sala>().ToList();
        }
        public Sala ObterPorId(int id)
        {
            return _contexto.Set<Sala>().Include(s => s.Jogadores).Include(s => s.Rodadas).FirstOrDefault(s => s.Id == id);
        }

        public void CriarSala(Sala sala)
        {
            _contexto.Set<Sala>().Add(sala);
            _contexto.SaveChanges();
        }

        public void AlterarSala(Sala sala)
        {
            _contexto.Set<Sala>().Update(sala);
            _contexto.SaveChanges();
        }

        public void ExcluirSala(Sala sala)
        {
            _contexto.Set<Sala>().Remove(sala);
            _contexto.SaveChanges();
        }
        public void InserirJogadorNaSala(Jogador jogador, Sala sala)
        {
            sala.Jogadores.Add(jogador);
            _contexto.SaveChanges();
        }

        public Sala BuscarSalaPorCodigo(int codigo)
        {
            return _contexto.Set<Sala>().FirstOrDefault(s => s.Codigo == codigo);
        }
    }
}
