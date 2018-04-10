using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class VaultKeepsController
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsController(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public VaultKeep AssociateVaultAndKeep([FromBody] VaultKeep vaultKeep)
        {
            return _repo.CreateOne(vaultKeep);
        }
    }
}