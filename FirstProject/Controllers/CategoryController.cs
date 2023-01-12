using AutoMapper;
using DTO;
using entities;
using logic_layer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IlogicCategory _Iservice;
        private readonly IMapper _imapper;
        public CategoryController(IlogicCategory service, IMapper mapper)
        {
            _Iservice = service;
            _imapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            IEnumerable<Category> p =await _Iservice.getCategories();
            IEnumerable<CategoryDTO> p2 = _imapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>> (p);
            if (p.Count() != 0)
                return Ok(p2);

            else
                return NotFound();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
