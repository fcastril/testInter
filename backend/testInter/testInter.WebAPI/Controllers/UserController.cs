using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testInter.Service;
using testInter.Data;
using Microsoft.AspNetCore.Authorization;

namespace testInter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<User> user = _userService.GetUsers();
            return Ok(user);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {

            User user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
       

        // POST api/<UserController>
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userService.InsertUser(user);
            user = _userService.GetUser(Repo.Security.Crypto.Decrypt(user.Email));

            return Ok(user);
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _userService.UpdateUser(user);
            user = _userService.GetUser(id);

            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            User user =  _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return Ok(user);
        }
    }
}
