using Paro.Repositories.RepositoryInterfaces;
using Paro.Models;
using Microsoft.EntityFrameworkCore;

namespace Paro.Repositories
{
    public class SalaRepository : IRepository<Sala>
    {
        private readonly DbContext _contexto;

        public SalaRepository(DbContext contexto)
        {
            _contexto = contexto;
        }

        public List<string> Validar(Sala sala)
        {
            var erros = new List<string>();

            if (sala is null)
            {
                erros.Add("Sala não pode ser nula.");
                return erros;
            }

            if (sala.Codigo <= 0)
                erros.Add("Código da sala é obrigatório e deve ser maior que zero.");

            if (sala.Status is null)
                erros.Add("Status da sala é obrigatório.");

            if (sala.QuantidadeRodadas <= 0)
                erros.Add("Quantidade de rodadas deve ser maior que zero.");

            if (sala.Jogadores is null || sala.Jogadores.Count == 0)
                erros.Add("A sala precisa ter pelo menos um jogador.");

            return erros;
        }

        public IEnumerable<Sala> Listar()
        {
            return _contexto.Set<Sala>().ToList();
        }
        public Sala ObterPorId(int id)
        {
            return _contexto.Set<Sala>().Find(id);
        }

        public void Adicionar(Sala sala)
        {
            _contexto.Set<Sala>().Add(sala);
            _contexto.SaveChanges();
        }

        public void Alterar(Sala sala)
        {
            _contexto.Set<Sala>().Update(sala);
            _contexto.SaveChanges();
        }

        public void Excluir(Sala sala)
        {
            _contexto.Set<Sala>().Remove(sala);
            _contexto.SaveChanges();
        }
    }
}
