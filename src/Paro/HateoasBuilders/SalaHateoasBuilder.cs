namespace Paro.HateoasBuilders
{
    public class SalaHateoasBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public SalaHateoasBuilder(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
        {
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
        }

        public string GeraLinks(string routeName, object routeValues)
        {
            var httpContext = _httpContextAccessor.HttpContext!;
            var url = _linkGenerator.GetUriByRouteValues(httpContext, routeName, routeValues);

            if (url is null)
            {
                throw new InvalidOperationException($"Não foi possível gerar link para a rota '{routeName}'.");
            }

            return url;
        }
    }
}