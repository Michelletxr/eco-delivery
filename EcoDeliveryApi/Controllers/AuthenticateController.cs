using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    
    private readonly DatabaseContext _context;
    private readonly IConfiguration _configuration;

    public AuthenticateController(DatabaseContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ActionResult<Mensageiro>> Login([FromBody] LoginRequest request)
    {
        var mensageiro = await _context.Mensageiros.Where(m => m.Nome == request.Nome).FirstOrDefaultAsync();
           
        if (mensageiro == null) return null; // Usuário ou senha incorretos

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, mensageiro.Id.ToString()),
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);
    
        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public required string Nome { get; set; }
    public required string Senha { get; set; }
}