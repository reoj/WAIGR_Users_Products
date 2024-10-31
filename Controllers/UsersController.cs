using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAIGR_Users_Products.Services;

namespace WAIGR_Users_Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _usersService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get User {id}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Post User");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id)
        {
            return Ok($"Put User {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete User {id}");
        }
    }
}