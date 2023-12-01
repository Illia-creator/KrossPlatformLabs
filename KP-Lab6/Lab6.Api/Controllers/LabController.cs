using Lab6.Api.Entities.Dtos;
using Lab6.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabController : ControllerBase
{

    private readonly LabService _service;
    public LabController(LabService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        await _service.Login(request, cancellationToken);

        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCustomerRequest request, CancellationToken cancellationToken)
    {
        await _service.Register(request, cancellationToken);

        return Ok();
    }

    [HttpGet("medications")]
    public async Task<IActionResult> GetMedications()
    {
        var result = await _service.GetMedicationResponse();

        return Ok(result);
    }

    [HttpGet("medications_filter")]
    public async Task<IActionResult> GetFilteredMedications([FromQuery] MedicationRequest request)
    {
        var result = await _service.GetCustomersByFiltersAsync(request);

        return Ok(result);
    }
}

[ApiController]
[Route("lab/tokens")]
public class TokensV1Controller : ControllerBase
{
    private readonly IHttpContextStorage _contextStorage;

    public TokensV1Controller(IHttpContextStorage contextStorage) => _contextStorage = contextStorage;

    [HttpGet]
    public IActionResult Get()
    {
        var data = _contextStorage.Get<AuthResponse>("auth_data");

        return Ok(data);
    }
}
