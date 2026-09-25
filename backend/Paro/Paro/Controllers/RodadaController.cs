using Microsoft.AspNetCore.Mvc;
using Paro.Services;
using Paro.Entities;

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

        [HttpPost(Name = "CriaRodada")]
        public IActionResult Create(Rodada rodada)
        {
            var criaRodada = _rodadaService.RodadasPreConfiguradas(rodada.SalaId, rodada.Tempo, rodada.Letra);
            if (criaRodada is null)
            {
                return BadRequest();
            }
            return StatusCode(201, criaRodada);
        }
    }
}
