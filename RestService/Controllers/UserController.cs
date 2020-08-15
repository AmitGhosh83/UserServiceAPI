using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using RestService.Data;
using RestService.Models;


namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = _userRepository.GetUserById(id);
            if(result==null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            if(model==null)
            {
                return BadRequest();
            }
            var contact = _userRepository.Add(model);
            return CreatedAtAction(nameof(Get), new { id = model.Id }, contact);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] User model)
        {
            if(id==null || model==null)
            {
                return BadRequest();
            }
            var result = _userRepository.Update(id, model);
            return Ok(result);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _userRepository.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
