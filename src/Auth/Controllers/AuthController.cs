using Auth.Requests.AutenticacaoRequests;
using Microsoft.AspNetCore.Mvc;
using Auth.Service;
using Auth.Hateoas;

namespace Auth.Controllers
{
    [ApiController]
    [Route("api/auth")]
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
            var links = new AuthHateoas().Links();

            return StatusCode(200, new { token, links});
        }


        [HttpPost("criar")]
        public IActionResult Criar([FromBody] CriarUsuarioRequest request)
        {
            var usuario = _factory.ObterUsuarioDao().CriarUsuario(request);

            if (usuario == null)
                return BadRequest("Erro ao criar usuário");

            var links = new AuthHateoas().Links();

            return StatusCode(201, new { links });
        }
    }
}