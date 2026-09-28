namespace Paro.Auth
{
    public class TokenService 
    {
        private readonly IConfiguration _config;
        private readonly string _secretKey;
        private readonly int _accessTokenExpiryMinutes;

        public TokenService(IConfiguration config, Factory factory)
        {
            _config = config;
            _secretKey = configuration["JwtSettings:Secret"];
            _accessTokenExpiryMinutes = configuration.GetValue<int>("JwtSettings:AccessTokenExpiryMinutes", 60);
        }

        public string GeraToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:SecretKey"],
                audience: _config["JwtSettings:SecretKey"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(_accessTokenExpiryMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}