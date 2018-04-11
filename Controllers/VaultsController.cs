using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController : Controller
    {
        private readonly VaultsRepository _repo;
        private readonly KeepsRepository _keepsRepo;

        public VaultsController(VaultsRepository repo, KeepsRepository keepsRepo)
        {
            _repo = repo;
            _keepsRepo = keepsRepo;
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

        [HttpDelete("{vaultId}/keeps/{keepId}")]
        public string DissociateVaultAndKeep(int vaultId, int keepId)
        {
            var user = HttpContext.User;
            if (user.Identity.Name != null)
            {
                var sessionId = user.Identity.Name;
                var vaultKeep = new VaultKeep();
                vaultKeep.VaultId = vaultId;
                vaultKeep.KeepId = keepId;
                vaultKeep.UserId = sessionId;
                return _repo.DissociateVaultAndKeep(vaultKeep);
            }
            return null;
        }

        [HttpGet("{id}/keeps")]
        public List<Keep> GetKeepsByVaultId(string id)
        {
            return _keepsRepo.GetByVaultId(id);
        }

        [HttpPut("{id}")]
        public Vault Update(int id, [FromBody] Vault vault)
        {
            if (ModelState.IsValid)
            {
                return _repo.FindOneAndUpdate(id, vault);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public string DeleteVaultById(int id)
        {
            return _repo.DeleteOne(id);
        }
    }
}