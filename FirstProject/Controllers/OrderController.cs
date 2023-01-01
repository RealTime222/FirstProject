using entities;
using Microsoft.AspNetCore.Mvc;
using logic_layer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IlogicOrder _Iservice;


        public OrderController(IlogicOrder service)
        {
            _Iservice = service;
        }
        // GET: api/<orderItem>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<orderItem>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<orderItem>
        [HttpPost]
        public async Task<Order> Post([FromBody] Order order)
        {
            Order orderRes = await _Iservice.AddOrder(order);
            return orderRes;
        }

        // PUT api/<orderItem>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<orderItem>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
