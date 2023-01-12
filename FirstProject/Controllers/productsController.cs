using logic_layer;
using Microsoft.AspNetCore.Mvc;
using entities;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly IlogicProduct _Iservice;
        private readonly IMapper _IMapper;


        public productsController(IlogicProduct service, IMapper mapper)
        {
            _Iservice = service;
            _IMapper = mapper;
        }

     

        // GET: api/<productsController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get(
            [FromQuery] int[]? CategoryId,[FromQuery] string? name, 
            [FromQuery] int? minPrice, [FromQuery] int? maxPrice,
            [FromQuery] int? start, [FromQuery] int? end, 
            [FromQuery] string? orderBy="price", [FromQuery] string? dir= "ASC")
        {
          
            IEnumerable<Product> p = await _Iservice.getProducts(CategoryId, name, minPrice, maxPrice, start,end, orderBy,dir);
           
            IEnumerable<ProductDTO> p2 =  _IMapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>>(p);
            if (p.Count() != 0)
                return p2;

            else
                return null ;



        }

        // GET api/<productsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<productsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<productsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<productsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
