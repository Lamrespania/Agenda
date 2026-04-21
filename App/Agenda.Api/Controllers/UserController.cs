namespace Agenda.Api.Controllers;

[Authorize(Roles = nameof(UserRole.Admin))]
[ApiController]
[Route("[controller]/[action]")]
public class UserController(ILogger<UserController> logger, UserService userService) : ControllerBase
{
    private readonly ILogger<UserController> _logger = logger;
    private readonly UserService _userService = userService;

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Get/id", nameof(UserController));

        GetReply response = await _userService.Get(id);

        if (response.Id == 0)
            return NotFound();

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] UserDto userDto)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Insert", nameof(UserController));

        InsertReply response = await _userService.Insert(userDto.Username, userDto.Password, userDto.Role);

        if (response.Message.ToUpper() != "OK")
            return BadRequest(response.Message);

        return CreatedAtAction(nameof(Get), new { response.Id }, null);
    }
}