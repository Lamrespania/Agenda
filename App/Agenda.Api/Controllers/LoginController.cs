namespace Agenda.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController(ILogger<LoginController> logger, LoginService loginService) : ControllerBase
{
    private readonly ILogger<LoginController> _logger = logger;
    private readonly LoginService _loginService = loginService;

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Login", nameof(LoginController));

        LoginReply response = await _loginService.Login(loginDto.Username, loginDto.Password);

        if (response.Authorized == false)
            return Unauthorized();

        return Ok(response);
    }
}