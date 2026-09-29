using Paro.Requests.AutenticacaoRequests;
using Microsoft.AspNetCore.Mvc;
using Paro.Utils;
using Paro.Auth;
namespace Paro.Controllers
{
    [ApiController]
    [Route("api/auth/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Factory _factory;
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService, Factory factory)
        {
            _tokenService = tokenService;
            _factory = factory;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _factory.ObterUsuarioDao().BuscaUsuario(request.Nome, request.Senha);

            if (usuario == null)
                return Unauthorized("Credenciais inválidas");

            var token = _tokenService.GeraToken(usuario);

            return Ok(new { token });
        }


        [HttpPost("criar")]
        public IActionResult Criar([FromBody] CriarUsuarioRequest request)
        {
            var usuario = _factory.ObterUsuarioDao().CriarUsuario(request);

            if (usuario == null)
                return BadRequest("Erro ao criar usuário");

            return StatusCode(201, "Usuário criado com sucesso!");
        }
    }
}