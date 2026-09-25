using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Entities;

namespace Paro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly Factory _factory;
        public SalaController(Factory factory)
        {
            _factory = factory;
        }
        [HttpGet("{id}", Name = "GetSala")]
        public IActionResult Get(int id)
        {
            var salaService = _factory.ObterSalaService();
            var sala = salaService.ObterSalaPorId(id);
            if (sala is null)
            {
                return NotFound();
            }
            return Ok(sala);
        }

        [HttpPost(Name = "CriaSala")]
        public IActionResult Create(Sala sala)
        {
            var salaService = _factory.ObterSalaService();
            salaService.CriarSala(sala);
            return CreatedAtAction(nameof(Get), new { id = sala.Id }, sala);
        }

        [HttpDelete("{id}", Name = "ExcluiSala")]
        public IActionResult Delete(int id)
        {
            var salaService = _factory.ObterSalaService();
            var sala = salaService.ObterSalaPorId(id);
            if (sala is null)
            {
                return NotFound();
            }
            salaService.ExcluirSala(id);
            return NoContent();
        }
        [HttpPut(Name = "AlteraSala")]
        public IActionResult Update(Sala sala)
        {
            var salaAlt = _factory.ObterSalaService().AlterarSala(sala);
            if (salaAlt is null)
            {
                return BadRequest();
            }
            return Ok(salaAlt);
        }
    }
}
