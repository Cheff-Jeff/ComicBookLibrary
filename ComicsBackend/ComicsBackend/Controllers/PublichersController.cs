using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublichersController : ControllerBase
    {
        private readonly ComicDbContext _context;
        public PublichersController(ComicDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllPublichers([FromQuery] QueryParameters parameters)
        {
            IQueryable<Publisher> publichers = _context.Publishers;
            publichers = publichers
                .Skip(parameters.Size * (parameters.Page - 1))
                .Take(parameters.Size);
            return Ok(await publichers.ToArrayAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Publisher), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPublicherById(int id)
        {
            Publisher? publisher = await _context.Publishers.FindAsync(id);
            return publisher == null ? NotFound() : Ok(publisher);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePublicher(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPublicherById), new { id = publisher.Id }, publisher);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePublicher(int id, Publisher publisher)
        {
            if (id != publisher.Id) return BadRequest();

            _context.Entry(publisher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePublicher(int id)
        {
            Publisher? publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null) return BadRequest();

            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
