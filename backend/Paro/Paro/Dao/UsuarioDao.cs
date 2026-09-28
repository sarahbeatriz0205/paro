namespace Paro.Dao
{
    public class UsuarioDao
    {
        private readonly DbContext _contexto;

        public UsuarioDao(DbContext contexto)
        {
            _contexto = contexto;
        }

        public Usuario? BuscaUsuario(string nome, string senha) 
        {
            var usuario = _contexto.Usuario.SingleOrDefault(u => u.Nome == request.Username && u.Senha == request.Password);
            return usuario;
        }
    }
}

