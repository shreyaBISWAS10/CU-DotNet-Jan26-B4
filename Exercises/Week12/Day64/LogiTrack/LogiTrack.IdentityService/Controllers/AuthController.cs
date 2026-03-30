using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        // Hardcoded user
        if (model.Email == "manager@test.com" && model.Password == "123")
        {
            var token = _tokenService.CreateToken(model.Email, "Manager");
            return Ok(new { access_token = token });
        }

        if (model.Email == "driver@test.com" && model.Password == "123")
        {
            var token = _tokenService.CreateToken(model.Email, "Driver");
            return Ok(new { access_token = token });
        }

        return Unauthorized();
    }
}