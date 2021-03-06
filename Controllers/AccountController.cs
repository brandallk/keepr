using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using keepr.Models.AuxiliaryModels;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserRepository _repo;

        public AccountController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<UserReturnModel> Register([FromBody] UserRegisterModel formData)
        {
            if (ModelState.IsValid)
            {
                UserReturnModel user = _repo.Register(formData);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
            }
            return null;
        }

        [HttpPost("login")]
        public async Task<UserReturnModel> Login([FromBody] UserLoginModel formData)
        {
            if (formData == null)
            {
                throw new System.ArgumentNullException(nameof(formData));
            }

            if (ModelState.IsValid)
            {
                UserReturnModel user = _repo.Login(formData);
                if (user != null)
                {
                    ClaimsPrincipal principal = user.SetClaims();
                    await HttpContext.SignInAsync(principal);
                    return user;
                }
            }
            return null;
        }

        [HttpGet("authenticate")]
        public UserReturnModel Authenticate()
        {
            var user = HttpContext.User;
            if (user.Identity.Name != null)
            {
                var id = user.Identity.Name;
                return _repo.GetUserById(id);
            }
            return null;
        }

        [HttpDelete("logout")]
        public async Task<string> Logout()
        {
            await HttpContext.SignOutAsync();
            return "User logged out";
        }

        [Authorize] // Only allow a signed-in user to visit this route
        [HttpPut]
        public UserReturnModel UpdateAccount([FromBody] UserReturnModel user)
        {
            var email = HttpContext.User.Claims.Where(context => context.Type == ClaimTypes.Email)
                .Select(context => context.Value).SingleOrDefault();
            var sessionUser = _repo.GetUserByEmail(email);

            if (sessionUser.Id == user.Id)
            {
                return _repo.UpdateUser(user);
            }
            return null;
        }

        [Authorize] // Only allow a signed-in user to visit this route
        [HttpPut("password-update")]
        public string ChangePassword([FromBody] UserChangePasswordModel user)
        {
            if (ModelState.IsValid)
            {
                var email = HttpContext.User.Claims.Where(context => context.Type == ClaimTypes.Email)
                    .Select(context => context.Value).SingleOrDefault();
                var sessionUser = _repo.GetUserByEmail(email);

                if (sessionUser.Id == user.Id)
                {
                    return _repo.ChangeUserPassword(user);
                }
            }
            return "Failed to update password";
        }
    }
}