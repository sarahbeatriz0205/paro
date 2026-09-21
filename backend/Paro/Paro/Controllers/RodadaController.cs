using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Models;

namespace Paro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RodadaController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetRodada")]
        public IActionResult Get(int id)
        {
            var rodada = RodadaService.ObterPorId(id);
            if (rodada is null)
            {
                return NotFound();
            }
            return Ok(rodada);
        }

        [HttpPost(Name = "CriaRodada")]
        public IActionResult Create(Rodada rodada)
        {
            var criaRodada = RodadaService.Adicionar(rodada);
            if (criaRodada is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = criaRodada.Id }, criaRodada);
        }
        [HttpDelete("{id}", Name = "ExcluiRodada")]
        public IActionResult Delete(int id)
        {
            var rodada = RodadaService.Excluir(id);
            if (rodada is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut(Name = "AlteraRodada")]
        public IActionResult Update(Rodada rodada)
        {
            var rodadadAlterada = RodadaService.Alterar(rodada);
            if (rodadadAlterada is null)
            {
                return BadRequest();
            }
            return Ok(rodadadAlterada);
        }
    }
}
