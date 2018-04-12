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
        private readonly TagsRepository _tagsRepo;

        public KeepsController(KeepsRepository repo, TagsRepository tagsRepo)
        {
            _repo = repo;
            _tagsRepo = tagsRepo;
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

        [HttpGet("search/{query}")]
        public List<Keep> GetKeepsByQuery(string query)
        {
            List<Keep> results = new List<Keep>();
            results.AddRange(_repo.FindByQueryString(query.ToLower()));
            results.AddRange(_repo.FindByTagQuery(query.ToLower()));
            return results;
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