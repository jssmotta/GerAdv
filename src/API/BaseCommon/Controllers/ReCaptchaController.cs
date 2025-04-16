using MenphisSI.WebApi.BaseCommon.Models;

namespace MenphisSI.BaseCommon.Controllers;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class ReCaptchaController(IConfiguration configuration) : ControllerBase
{ 
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _siteSecret = configuration["AppSettings:SERVER_SITE_KEY"] ?? throw new Exception("SERVER_SITE_KEY null");
   
    [HttpPost]
    public async Task<IActionResult> Verify([FromBody] ReCaptchaRequest request)
    {
        if (string.IsNullOrEmpty(request.CaptchaValue))
        {
            _logger.Error("Captcha value is required.");
            return BadRequest("Captcha value is required.");
        }

        var response = await _httpClient.PostAsync(
            $"https://www.google.com/recaptcha/api/siteverify?secret={_siteSecret}&response={request.CaptchaValue}",
            null);

        if (!response.IsSuccessStatusCode)
        {
            _logger.Error("Captcha verifying reCAPTCHA.");
            return StatusCode((int)response.StatusCode, "Error verifying reCAPTCHA.");
        }

        try
        {
            _logger.Info("Starting Captcha verifying reCAPTCHA.");
            var responseData = await response.Content.ReadAsStringAsync();
            _logger.Info("Captcha verifying reCAPTCHA ok.");
            return Ok(responseData);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Error verifying reCAPTCHA.");
            return StatusCode(500, "Error verifying reCAPTCHA.");
        }
    }
}

