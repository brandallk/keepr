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

        public UsersController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{ id }/keeps")]
        // Get keeps by User ID
        public List<Keep> GetKeepsByUserId(string id)
        {
            return _repo.GetKeepsByUserId(id);
        }
    }
}