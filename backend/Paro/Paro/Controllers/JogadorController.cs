using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Models;

namespace Paro.Controllers
{
    [ApiController] 
    [Route("[controller]")]
    public class JogadorController : ControllerBase
    {
        [HttpGet(Name = "GetAllJogador")]
        public IEnumerable<Jogador> GetAll()
        {
            return JogadorService.Listar();
        }

        [HttpGet("{id}", Name = "GetJogador")]
        public IActionResult Get(int id)
        {
            var jogador = JogadorService.ObterPorId(id);
            if (jogador is null)
            {
                return NotFound();
            }
            return Ok(jogador);
        }

        [HttpPost(Name = "CriaJogador")]
        public IActionResult Create(Jogador jogador)
        {
            var criaJogador = JogadorService.Adicionar(jogador);
            if (criaJogador is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = criaJogador.Id }, criaJogador);
        }
        [HttpDelete("{id}", Name = "ExcluiJogador")]
        public IActionResult Delete(int id)
        {
            var jogador = JogadorService.Excluir(id);
            if (jogador is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut(Name = "AlteraJogador")]
        public IActionResult Update(Jogador jogador)
        {
            var jogadorAlterado = JogadorService.Alterar(jogador);
            if (jogadorAlterado is null)
            {
                return BadRequest();
            }
            return Ok(jogadorAlterado);
        }
    }
}
