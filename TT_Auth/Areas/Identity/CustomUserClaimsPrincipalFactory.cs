using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TT_Auth.Models.Entity;

public class CustomUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserInfo>
{
    public CustomUserClaimsPrincipalFactory(
        UserManager<UserInfo> userManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, optionsAccessor)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserInfo user)
    {
        var identity = await base.GenerateClaimsAsync(user);
        identity.AddClaim(new Claim("Id", user.Id));
        identity.AddClaim(new Claim("RoleId", user.RoleId.ToString()));
        return identity;
    }
}