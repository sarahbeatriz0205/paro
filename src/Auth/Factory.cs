using Auth.Dao;
using Auth.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth
{
    public class Factory
    {
        private readonly IConfiguration _configuration;
        public Factory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Database ObterConexaoDb()
        {
            // montando configuração do banco de dados
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<Database>()
                .UseSqlite(connectionString)
                .Options;
            return new Database(options);
        }
        public UsuarioDao ObterUsuarioDao()
        {
            return new UsuarioDao(ObterConexaoDb());
        }
    }
}
