using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAIGR_Users_Products.DTOs;
using WAIGR_Users_Products.Entities;
using WAIGR_Users_Products.Services;

namespace WAIGR_Users_Products.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _usersService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result = _usersService.GetUserById(id);
            return result is not null ? Ok(result) : NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO user)
        {
            var result = _usersService.CreateUser(user);
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateUserDTO user)
        {
            var result = _usersService.UpdateUser(id, user);
            return result is not null ? Ok(result) : BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _usersService.DeleteUser(id);
            return result is not null ? Ok() : BadRequest();
        }
    }
}