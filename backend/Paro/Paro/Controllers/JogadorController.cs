using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Models;
using Paro.Repositories.RepositoryInterfaces;

namespace Paro.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly JogadorService _jogadorService;
        public JogadorController(JogadorService jogadorService)
        {
            _jogadorService = jogadorService;
        }

        [HttpGet(Name = "GetAllJogador")]
        public IEnumerable<Jogador> GetAll()
        {
            return _jogadorService.Listar();
        }

        [HttpGet("{id}", Name = "GetJogador")]
        public IActionResult Get(int id)
        {
            var jogador = _jogadorService.ObterPorId(id);
            if (jogador is null)
            {
                return NotFound();
            }
            return Ok(jogador);
        }

        [HttpPost(Name = "CriaJogador")]
        public IActionResult Create(Jogador jogador)
        {
            List<string> validacao = _jogadorService.Validar(jogador);
            if (validacao.Count > 0)
            {
                return BadRequest(validacao);
            }
            _jogadorService.Adicionar(jogador);
            return CreatedAtAction(nameof(Get), new { id = jogador.Id }, jogador);
        }
        [HttpDelete("{id}", Name = "ExcluiJogador")]
        public IActionResult Delete(Jogador jogador)
        {
            List<string> validacao = _jogadorService.Validar(jogador);
            if (validacao.Count > 0)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut(Name = "AlteraJogador")]
        public IActionResult Update(Jogador jogador)
        {
            List<string> validacao = _jogadorService.Validar(jogador);
            if (validacao.Count > 0)
            {
                return BadRequest(validacao);
            }
            return Ok();
        }
    }
}
