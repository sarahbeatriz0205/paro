using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Paro.Utils;
using Paro.Repositories;
using Paro.Services;
using Paro.Dao;

namespace Paro
{
    public class Factory
    {
        private readonly IConfiguration _configuration;
        public Factory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ContextDb ObterConexaoDb()
        {
            // montando configuração do banco de dados
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<ContextDb>()
                .UseSqlite(connectionString)
                .Options;
            return new ContextDb(options);
        }
        public SalaDao ObterSalaDao()
        {
            return new SalaDao(ObterConexaoDb());
        }
        public JogadorDao ObterJogadorDao()
        {
            return new JogadorDao(ObterConexaoDb());
        }

        public RodadaDao ObterRodadaDao()
        {
            return new RodadaDao(ObterConexaoDb());
        }

        public CategoriaDao ObterCategoriaDao()
        {
            return new CategoriaDao(ObterConexaoDb());
        }

        public SalaService ObterSalaService()
        {
            return new SalaService(this);
        }
        public JogadorService ObterJogadorService()
        {
            return new JogadorService(this);
        }

        public CategoriaService ObterCategoriaService()
        {
            return new CategoriaService(this);
        }
    }
}
