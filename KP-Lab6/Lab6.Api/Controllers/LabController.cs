using Lab6.Api.Entities.Dtos;
using Lab6.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Api.Controllers
{
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

        [Authorize]
        [HttpGet("medications")]
        public async Task<IActionResult> GetMedications()
        {
            var result = await _service.GetMedicationResponse();

            return Ok(result);
        }

        [Authorize]
        [HttpGet("medications_filter")]
        public async Task<IActionResult> GetFilteredMedications([FromQuery] MedicationRequest request)
        {
            var result = await _service.GetCustomersByFiltersAsync(request);

            return Ok(result);
        }
    }
}
