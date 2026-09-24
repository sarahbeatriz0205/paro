using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Models;

namespace Paro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetSala")]
        public IActionResult Get(int id)
        {
            var sala = SalaService.ObterPorId(id);
            if (sala is null)
            {
                return NotFound();
            }
            return Ok(sala);
        }

        [HttpPost(Name = "CriaSala")]
        public IActionResult Create(Sala sala)
        {
            var criaSala = SalaService.CriarSala(sala);
            if (criaSala is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = criaSala.Id }, criaSala);
        }
        [HttpDelete("{id}", Name = "ExcluiSala")]
        public IActionResult Delete(int id)
        {
            var sala = SalaService.ExcluirSala(id);
            if (sala is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut(Name = "AlteraSala")]
        public IActionResult Update(Sala sala)
        {
            var salaAlt = SalaService.AlterarSala(sala);
            if (salaAlt is null)
            {
                return BadRequest();
            }
            return Ok(salaAlt);
        }
    }
}
