using Paro.Utils;
using Paro.Models;
using Paro.Requests.AutenticacaoRequests;

namespace Paro.Dao
{
    public class UsuarioDao
    {
        private readonly ContextDb _contexto;

        public UsuarioDao(ContextDb contexto)
        {
            _contexto = contexto;
        }

        public Usuario? BuscaUsuario(string nome, string senha) 
        {
            var usuario = _contexto.Usuario.SingleOrDefault(u => u.Nome == nome && u.Senha == senha);
            return usuario;
        }

        public Usuario CriarUsuario(CriarUsuarioRequest request)
        {
            var usuario = new Usuario
            {
                Nome = request.Nome,
                Senha = request.Senha
            };
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
            return usuario;
        }
    }
}

