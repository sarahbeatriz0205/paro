using Microsoft.AspNetCore.Mvc;

namespace Paro.Controllers
{
    [ApiController] // indica que este controlador é um controlador de API, habilitando recursos como validação automática de modelo e respostas automáticas para erros de validação
    [Route("[controller]")] // mapeia as rotas para o controlador WeatherForecastController
    public class WeatherForecastController : ControllerBase // ControllerBase é a classe base para controladores de API no ASP.NET Core
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")] // define que este método responde a requisições HTTP GET e atribui um nome à rota
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
