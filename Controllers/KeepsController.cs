using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepsRepository _repo;

        public KeepsController(KeepsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Keep CreateKeep([FromBody] Keep keep)
        {
            if (ModelState.IsValid)
            {
                return _repo.CreateOne(keep);
            }
            return null;
        }

        [HttpGet("public")]
        public List<Keep> GetPublicKeeps()
        {
            return _repo.GetPublicKeeps();
        }

        [HttpPut("{id}")]
        public Keep Update(int id, [FromBody] Keep keep)
        {
            if (ModelState.IsValid)
            {
                return _repo.FindOneAndUpdate(id, keep);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _repo.DeleteOne(id);
        }
    }
}