using System.Security.Claims;

namespace MenphisSI.BaseCommon;

public static class UserTools
{
    public static int GetAuthenticatedUserId(IHttpContextAccessor _httpContextAccessor)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("id");

        return userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value)
            ? throw new Exception("User Id invalid!")
            : !int.TryParse(userIdClaim.Value, out int userId) ? throw new Exception("User Id invalid!") : userId;
    }
}