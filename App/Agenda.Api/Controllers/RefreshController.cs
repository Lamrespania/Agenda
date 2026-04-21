namespace Agenda.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RefreshController(ILogger<RefreshController> logger, RefreshService refreshService) : ControllerBase
{
    private readonly ILogger<RefreshController> _logger = logger;
    private readonly RefreshService _refreshService = refreshService;

    [HttpPost]
    public async Task<IActionResult> Refresh([FromBody] RefreshDto refreshDto)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Refresh", nameof(RefreshController));

        RefreshReply response = await _refreshService.Refresh(refreshDto.Username, refreshDto.RefreshToken);

        return Ok(response);
    }
}