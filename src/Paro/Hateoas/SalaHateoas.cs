using Paro.Models;

namespace Paro.Hateoas
{
    public class SalaHateoas
    {
        public List<Link> Links(Sala sala)
        {
            List<Link> links = new List<Link>();

            links.Add(new Link($"/api/sala/{sala.Id}", "self", "GET"));
            links.Add(new Link($"/api/sala/{sala.Codigo}/entrar", "entrar", "POST"));
            return links;
        }
    }
}