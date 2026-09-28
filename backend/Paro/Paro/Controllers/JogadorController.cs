using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Models;

namespace Paro.Controllers
{
    [ApiController] 
    [Route("[api/controller]")]
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
            _jogadorService.CriarJogador(jogador);
            return CreatedAtAction(nameof(Get), new { id = jogador.Id }, jogador);
        }
        [HttpDelete("{id}", Name = "ExcluiJogador")]
        public IActionResult Delete(Jogador jogador)
        {
            _jogadorService.ExcluirJogador(jogador);
            return NoContent();
        }
        [HttpPut(Name = "AlteraJogador")]
        public IActionResult Update(Jogador jogador)
        {
            _jogadorService.AlterarJogador(jogador);
            return Ok();
        }
    }
}
