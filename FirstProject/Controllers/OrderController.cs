using entities;
using Microsoft.AspNetCore.Mvc;
using logic_layer;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IlogicOrder _Iservice;
        private readonly IMapper _imapper;

        public OrderController(IlogicOrder service, IMapper mapper)
        {
            _Iservice = service;
            _imapper = mapper;
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
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            Order orderRes = await _Iservice.AddOrder(order);
            if (orderRes!=null)
                 return Ok();
            return null;
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
