using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultsController
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

        [HttpGet("{id}/keeps")]
        public List<Keep> GetKeepsByVaultId(string id)
        {
            return _keepsRepo.GetByVaultId(id);
        }
    }
}