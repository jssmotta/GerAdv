#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Controller;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class EMPClassRiscosController
{
    [HttpGet("/health/EMPClassRiscos")]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public IActionResult HealthCheck()
    {
        return Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
    }
}