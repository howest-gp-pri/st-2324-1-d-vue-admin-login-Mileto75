using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pri.Vue.Store.Api.Core.Interfaces.Services
{
    public interface IJwtService
    {
        JwtSecurityToken GenerateToken(List<Claim> userClaims);
        string SerializeToken(JwtSecurityToken token);
    }
}
