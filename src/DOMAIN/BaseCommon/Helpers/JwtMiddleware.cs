using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MenphisSI.BaseCommon;

public class JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
{
    private readonly RequestDelegate _next = next;
    private readonly AppSettings _appSettings = appSettings.Value;

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
        var uris = context.Request.Path.Value?.Split('/');

        var uri = uris != null && uris.Length > 3 ? uris[3] : "MDSDEMO";

        if (token != null)
            await AttachUserToContext(context, userService, token, uri ?? "");

        await _next(context);
    }

    private async Task AttachUserToContext(HttpContext context, IUserService userService, string token, string uri)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // Attach user to context on successful JWT validation
            context.Items["User"] = await userService.GetById(userId, uri);
        }
        catch (SecurityTokenExpiredException ex)
        {
            // Log token expired exception
            Console.WriteLine($"Token expired: {ex.Message}");
        }
        catch (SecurityTokenInvalidSignatureException ex)
        {
            // Log invalid signature exception
            Console.WriteLine($"Invalid token signature: {ex.Message}");
        }
        catch (SecurityTokenInvalidIssuerException ex)
        {
            // Log invalid issuer exception
            Console.WriteLine($"Invalid token issuer: {ex.Message}");
        }
        catch (SecurityTokenInvalidAudienceException ex)
        {
            // Log invalid audience exception
            Console.WriteLine($"Invalid token audience: {ex.Message}");
        }
        catch (SecurityTokenException ex)
        {
            // Log general security token exception
            Console.WriteLine($"Token validation error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Log any other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}