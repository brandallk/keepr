using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeeptagsController
    {
        private readonly KeeptagsRepository _repo;

        public KeeptagsController(KeeptagsRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public KeepTag CreateKeepTag([FromBody] KeepTag keeptag)
        {
            return _repo.CreateOne(keeptag);
        }
    }
}