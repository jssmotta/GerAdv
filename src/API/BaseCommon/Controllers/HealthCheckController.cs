namespace MenphisSI.HealthCheck;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    [Route("/health/Memory")]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public IActionResult HealthCheck()
    {
        return Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
    }
}
