namespace Agenda.Api.Controllers;

[Authorize(Roles = $"{nameof(UserRole.Manager)},{nameof(UserRole.Admin)}")]
[ApiController]
[Route("[controller]/[action]")]
public class AppointmentController(ILogger<AppointmentController> logger, AppointmentDbService appointmentService) : ControllerBase
{
    private readonly ILogger<AppointmentController> _logger = logger;
    private readonly AppointmentDbService _appointmentService = appointmentService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Get", nameof(AppointmentController));

        IEnumerable<Appointment> appointments = await _appointmentService.Get();

        return Ok(appointments);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Get/id", nameof(AppointmentController));

        Appointment appointment = await _appointmentService.Get(id);

        if (appointment == null)
            return NotFound();

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Appointment appointment)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Insert", nameof(AppointmentController));

        int id = await _appointmentService.Insert(appointment);

        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Delete", nameof(AppointmentController));

        bool deleted = await _appointmentService.Delete(id);

        if (deleted)
            return NoContent();

        return NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Appointment appointment)
    {
        _logger.LogInformation(ApiConstants.ACTION_INFO, "Update", nameof(AppointmentController));

        bool updated = await _appointmentService.Update(appointment);

        if (updated)
            return NoContent();

        return NotFound();
    }
}