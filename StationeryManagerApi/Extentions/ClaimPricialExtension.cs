using System.Security.Claims;
using StationeryManagerLib.Entities;

namespace StationeryManagerApi.Extentions
{
    public static class ClaimPricialExtension
    {
        public static string GetClaim(this ClaimsPrincipal user, string claimType)
        {
            return user?.Claims.FirstOrDefault(c => c.Type == claimType)?.Value ?? string.Empty;
        }

        public static ClaimModel ToClaimModel(this ClaimsPrincipal user)
        {
            return new ClaimModel
            {
                UserId = user.GetClaim(ClaimTypes.NameIdentifier), 
                UserName = user.GetClaim(ClaimTypes.Name),
                Email = user.GetClaim(ClaimTypes.Email),
                Phone = user.GetClaim(ClaimTypes.MobilePhone)
            };
        }
    }
}
