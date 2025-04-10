using System.Security.Claims;

namespace Web.Extensions;

public static class ClaimsPrincipalExtension
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userId, out Guid guid) ? guid : null;
    }
}