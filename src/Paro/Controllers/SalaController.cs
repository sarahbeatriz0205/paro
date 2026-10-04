using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Paro.Models;
using Paro.Requests.SalaRequests;
using Paro.Serializers;
using Paro.Services;
using Paro.Hateoas;

namespace Paro.Controllers
{
    [ApiController]
    [Route("api/sala")]
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

        [Authorize]
        [HttpPost("criar-sala", Name = "criar-sala")]
        public IActionResult Create([FromBody] CriarSalaRequest request)
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var nomeOrganizador = User.FindFirstValue(ClaimTypes.Name);

            SalaService salaService = _factory.ObterSalaService();
            var salaCriada = salaService.CriarSala(request, usuarioId, nomeOrganizador);
            return StatusCode(201, salaCriada);
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

        [HttpPost("{codigo}", Name ="entrar")]
        public IActionResult Entrar(EntrarRequest request)
        {
            SalaService salaService = _factory.ObterSalaService();
            Sala sala = salaService.ObterSalaPorCodigo(request.Codigo);
            var jogadorEntrou = salaService.EntrarNaSala(request.NomeJogador, request.Codigo);

            var links = new SalaHateoas().Links(sala);
            var linkEspecifico = links[0];
            if (sala.Ativa != true) 
            {
                linkEspecifico = links[1];
            }
            linkEspecifico = links[0];

            return StatusCode(201, new { jogadorEntrou, links = linkEspecifico });
        }
    }
}