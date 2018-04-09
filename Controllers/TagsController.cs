using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class TagsController
    {
        private readonly TagsRepository _repo;

        public TagsController(TagsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public Tag CreateTag([FromBody] Tag tag)
        {
            return _repo.CreateOne(tag);
        }

        [HttpGet("{tagname}")]
        // GET a tag by name
        public Tag GetOneByName(string tagname)
        {
            return _repo.GetOneByName(tagname);
        }
    }
}