using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Data;
using ProductsWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return StatusCode(201, newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updateProduct)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
