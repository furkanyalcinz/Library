using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Helpers
{
    public static class JwtDecoder
    {
        public static JwtSecurityToken JwtDecode(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = tokenHandler.ReadJwtToken(token);
            return jwt;
        }
    }
}
