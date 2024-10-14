using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


public interface IAuthService
{
    string Authenticate(string nome, string senha);
}

public class AuthService : IAuthService
{
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(DatabaseContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public string? Authenticate(string nome, string senha)
    {
        // Verificar se o mensageiro existe e a senha está correta
        var mensageiro = _context.Mensageiros.FirstOrDefault(m => m.Nome == nome && m.Senha == senha);
        
        if (mensageiro == null)
            return null; // Usuário ou senha incorretos

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, mensageiro.Id.ToString())
        };

        Console.WriteLine("claims", claims.Length);

        // Gerar token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
