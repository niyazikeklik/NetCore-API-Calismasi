using APIproje.Models;
using APIproje.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIproje.Controllers {
    [ApiController]
    [Route("api/")]
    public class UsersController : ControllerBase {
       
        private readonly IKullnicilar _userRepositories;
        public UsersController(IKullnicilar userRepositories) {
            _userRepositories = userRepositories;
        }
        [HttpGet]
        public async Task<IEnumerable<Users>> GetUsers() {
            return await _userRepositories.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id) {
            return await _userRepositories.Get(id);
        }
        [HttpGet("{eposta}")]
        public async Task<ActionResult<Users>> GetUsers(string eposta) {
            return await _userRepositories.Geteposta(eposta);
        }
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers([FromBody] Users user)
        {
            var newUser = await _userRepositories.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.id }, newUser);
        }
        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Users user) {
            if(id != user.id)
                return BadRequest();
            await _userRepositories.Update(user);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            var silinecekKisi = await _userRepositories.Get(id);
            if(silinecekKisi == null)
                return NotFound();

            await _userRepositories.Delete(silinecekKisi.id);
            return NoContent();
        }
    }
}
