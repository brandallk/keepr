using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController
    {
        private readonly VaultsRepository _repo;

        public VaultsController(VaultsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Vault CreateVault([FromBody] Vault vault)
        {
            return _repo.CreateOne(vault);
        }

        [HttpPost("keeps")]
        public VaultKeep AssociateVaultAndKeep([FromBody] VaultKeep vaultKeep)
        {
            return _repo.AssociateVaultAndKeep(vaultKeep);
        }
    }
}