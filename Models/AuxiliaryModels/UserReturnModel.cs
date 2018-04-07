using System.Collections.Generic;
using System.Security.Claims;

namespace keepr.Models.AuxiliaryModels
{
    public class UserReturnModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public ClaimsPrincipal SetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, Id.ToString())
            };
            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            return principal;
        }
    }
}