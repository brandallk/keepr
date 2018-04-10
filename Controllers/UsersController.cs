using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class UsersController
    {
        private readonly UserRepository _repo;
        private readonly VaultsRepository _vaultsRepo;

        public UsersController(UserRepository repo, VaultsRepository vaultsRepo)
        {
            _repo = repo;
            _vaultsRepo = vaultsRepo;
        }

        [HttpGet("{id}/keeps")]
        // Get keeps by User ID
        public List<Keep> GetKeepsByUserId(string id)
        {
            return _repo.GetKeepsByUserId(id);
        }

        [HttpGet("{id}/vaults")]
        // Get vaults by User ID
        public List<Vault> GetVaultsByUserId(string id)
        {
            return _vaultsRepo.GetByUserId(id);
        }
    }
}