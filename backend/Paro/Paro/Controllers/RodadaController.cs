using Microsoft.AspNetCore.Mvc;
using Paro.Models;
using Paro.Requests.RodadaRequests;
using Paro.Services;

namespace Paro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RodadaController : ControllerBase
    {
        private readonly RodadaService _rodadaService;
        public RodadaController(RodadaService rodadaService)
        {
            _rodadaService = rodadaService;
        }
        [HttpGet("{id}", Name = "GetRodada")]
        public IActionResult Get(int id)
        {
            var rodada = _rodadaService.ObterRodadaPorId(id);
            if (rodada is null)
            {
                return NotFound();
            }
            return Ok(rodada);
        }

        [HttpPost("{salaId}", Name = "CriaRodada")]
        public IActionResult Create([FromRoute] int salaId, [FromBody] CriarRodadaRequest request)
        {
            var criaRodada = _rodadaService.RodadasPreConfiguradas(salaId, request.Tempo);
            if (criaRodada is null)
            {
                return BadRequest();
            }
            return StatusCode(201, criaRodada);
        }
    }
}
