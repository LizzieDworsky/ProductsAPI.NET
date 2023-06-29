using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Data;
using ProductsWebAPI.DTOs;
using ProductsWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET api/Reviews/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // Custom Endpoint
        // GET api/Reviews/Product/5
        [HttpGet("Product/{id}")]
        public IActionResult GetByProductId(int id)  // refactor to only return the reviews
        {
            var reviews = _context.Reviews.Where(r => r.ProductId == id).ToList();
            return Ok(reviews);
        }

        // POST api/Reviews
        [HttpPost]
        public IActionResult Post([FromBody] Review newReview)
        {
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return StatusCode(201, newReview);
        }

        // PUT api/Reviews/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review updateReview)
        {
            var review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
            if (review == null)
            {
                return NotFound();
            }
            review.Text = updateReview.Text;
            review.Rating = updateReview.Rating;
            _context.Reviews.Update(review);
            _context.SaveChanges();
            return Ok(review);
        }

        // DELETE api/Reviews/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
