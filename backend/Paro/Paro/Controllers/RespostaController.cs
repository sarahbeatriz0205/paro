using Microsoft.AspNetCore.Mvc;
using Paro.Requests.RespostaRequests;

namespace Paro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RespostaController : ControllerBase
    {
        private readonly Factory _factory;
        public RespostaController(Factory factory)
        {
            _factory = factory;
        }

        [HttpPost("enviaResposta", Name = "EnviarResposta")]
        public IActionResult EnviarResposta([FromBody] EnviarRespostaRequest request)
        {
            var respostaService = _factory.ObterRespostaService();
            var respostaCriada = respostaService.CriarResposta(request);
            if (respostaCriada is null)
            {
                return BadRequest();
            }
            return StatusCode(201, respostaCriada);
        }
    }
}