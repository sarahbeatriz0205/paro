using Microsoft.EntityFrameworkCore;
using Paro.Utils;
using Paro.Models;
using Paro.Repositories.RepositoryInterfaces;

namespace Paro.Repositories
{
    public class JogadorRepository : IRepository<Jogador>
    {
        private readonly AppDbContext _contexto;

        public JogadorRepository(AppDbContext contexto)
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

        public void Adicionar(Jogador jogador)
        {
            _contexto.Set<Jogador>().Add(jogador);
            _contexto.SaveChanges();
        }

        public void Alterar(Jogador jogador)
        {
            _contexto.Set<Jogador>().Update(jogador);
            _contexto.SaveChanges();
        }

        public void Excluir(Jogador jogador)
        {
            _contexto.Set<Jogador>().Remove(jogador);
            _contexto.SaveChanges();
        }
    }
}