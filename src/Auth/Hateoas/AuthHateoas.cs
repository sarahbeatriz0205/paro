namespace Auth.Hateoas
{
    public class AuthHateoas
    {
       public List<Link> Links()
        {
            List<Link> links = new List<Link>(); 
            links.Add(new Link("/api/auth/login", "login", "POST"));
            links.Add(new Link("/api/auth/criar", "criar", "POST"));
            return links;
        }
    }
}