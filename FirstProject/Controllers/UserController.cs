using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


using logic_layer;
using entities;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Ilogic _Iservice;

        
        public UserController(Ilogic service)
        {
            _Iservice = service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<user?> Get([FromQuery] string email, [FromQuery] int password)
        {
            user theUser = await _Iservice.getUser(password, email);
            if (theUser != null)
                return theUser;

            else
                return null;



        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<user>> Post([FromBody] user user)
        {
            bool ans = await _Iservice.addUser(user);
            if (ans == true)
                return Ok();
            else return NoContent();


        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] user userToUpdate)
        { 
            
            bool ans = await _Iservice.updateUser(userToUpdate,id);
            
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
