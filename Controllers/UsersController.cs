using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UserRepository _repo;
        private readonly KeepsRepository _keepsRepo;
        private readonly VaultsRepository _vaultsRepo;

        public UsersController(UserRepository repo,  KeepsRepository keepsRepo, VaultsRepository vaultsRepo)
        {
            _repo = repo;
            _keepsRepo = keepsRepo;
            _vaultsRepo = vaultsRepo;
        }

        [HttpGet("{id}/keeps")]
        // Get keeps by User ID
        public List<Keep> GetKeepsByUserId(string id)
        {
            // Get the userId from the users's erver session as more-secure alternative to passing it in from the front-end:
            var user = HttpContext.User;
            if (user.Identity.Name != null)
            {
                var sessionId = user.Identity.Name;
                return _keepsRepo.GetByUserId(sessionId);
            }
            return null;

            // Alternative -- Use the userId passed in from the front end as a route parameter:
            // return _keepsRepo.GetByUserId(id);
        }

        [HttpGet("{id}/vaults")]
        // Get vaults by User ID
        public List<Vault> GetVaultsByUserId(string id)
        {
            // Get the userId from the users's erver session as more-secure alternative to passing it in from the front-end:
            var user = HttpContext.User;
            if (user.Identity.Name != null)
            {
                var sessionId = user.Identity.Name;
                return _vaultsRepo.GetByUserId(sessionId);
            }
            return null;

            // Alternative -- Use the userId passed in from the front end as a route parameter:
            // return _vaultsRepo.GetByUserId(id);
        }
    }
}