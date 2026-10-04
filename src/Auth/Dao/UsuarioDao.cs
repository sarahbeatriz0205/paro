using Auth.Data;
using Auth.Models;
using Auth.Requests.AutenticacaoRequests;

namespace Auth.Dao
{
    public class UsuarioDao
    {
        private readonly Database _contexto;

        public UsuarioDao(Database contexto)
        {
            _contexto = contexto;
        }

        public Usuario? BuscaUsuario(string nome, string senha) 
        {
            var usuario = _contexto.Usuario.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);
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

