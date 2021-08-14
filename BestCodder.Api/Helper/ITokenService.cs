using Microsoft.AspNetCore.Identity;

namespace BestCodder.Api.Helper
{
    public interface ITokenService
    {
        string CreateToken(IdentityUser user);
    }
}
