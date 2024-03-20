using System.Security.Claims;

namespace BookReviewerV2.MVC.Infrastructure;

public static class ClaimsPrincipalExtensions
{
    public static string Id(this ClaimsPrincipal user)
        => user.FindFirst(ClaimTypes.NameIdentifier).Value;

    public static bool IsAdmin(this ClaimsPrincipal user)
        => user.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Administrator");
}