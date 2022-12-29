using Microsoft.AspNetCore.Mvc;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class passwordController : ControllerBase
    {
        // GET: api/<passwordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<passwordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<passwordController>
        [HttpPost]
        public int validate([FromBody] string value)
        {
            Result result = Zxcvbn.Core.EvaluatePassword(value);
            
            return result.Score;
        }

        // PUT api/<passwordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<passwordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
