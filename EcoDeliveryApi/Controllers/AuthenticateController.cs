using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticateController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var token = _authService.Authenticate(request.Nome, request.Senha);
        
        if (token == null)
            return Unauthorized();

        return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public required string Nome { get; set; }
    public required string Senha { get; set; }
}