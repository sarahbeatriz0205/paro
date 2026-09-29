using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Paro.Models;
using Paro.Requests.SalaRequests;
using Paro.Serializers;
using Paro.Services;

namespace Paro.Controllers
{
    [ApiController]
    [Route("api/sala/[controller]")]
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
            Sala? sala = salaService.ObterSalaPorId(id);
            if (sala is null)
            {
                return NotFound();
            }
            return Ok(sala);
        }

        [HttpPost(Name = "CriaSala")]
        public IActionResult Create([FromBody] CriarSalaRequest request)
        {
            SalaService salaService = _factory.ObterSalaService();
            var salaCriada = salaService.CriarSala(request);
            return CreatedAtAction(nameof(Get), new { id = salaCriada.Id }, salaCriada);
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
        [HttpPut("{id}", Name = "AlteraSala")]
        public IActionResult Update(int id, AlterarSalaRequest request)
        {
            var salaAlt = _factory.ObterSalaService().AlterarSala(id, request);
            if (salaAlt is null)
            {
                return BadRequest();
            }
            return Ok(salaAlt);
        }

        [HttpPost("{codigo}", Name ="Entrar")]
        public IActionResult Entrar(EntrarRequest request)
        {
            SalaService salaService = _factory.ObterSalaService();
            var jogadorEntrou = salaService.EntrarNaSala(request.NomeJogador, request.Codigo);
            return CreatedAtAction(nameof(Get), new { id = jogadorEntrou.Id }, jogadorEntrou);
        }
    }
}
