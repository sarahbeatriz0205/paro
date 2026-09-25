using Microsoft.EntityFrameworkCore;
using Paro.Utils;
using Paro.Models;
using Paro.Repositories.RepositoryInterfaces;
using Paro.Entities;

namespace Paro.Repositories
{
    public class JogadorDao : IJogadorDao<Jogador>
    {
        private readonly ContextDb _contexto;

        public JogadorDao(ContextDb contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Jogador> Listar()
        {
            return _contexto.Set<Jogador>().ToList();
        }
        public Jogador ObterPorId(int id)
        {
            return _contexto.Set<Jogador>().Find(id);
        }

        public void CriarJogador(Jogador jogador)
        {
            _contexto.Set<Jogador>().Add(jogador);
            _contexto.SaveChanges();
        }

        public void AlterarJogador(Jogador jogador)
        {
            _contexto.Set<Jogador>().Update(jogador);
            _contexto.SaveChanges();
        }

        public void ExcluirJogador(Jogador jogador)
        {
            _contexto.Set<Jogador>().Remove(jogador);
            _contexto.SaveChanges();
        }
    }
}