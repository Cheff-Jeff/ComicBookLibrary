using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly ComicDbContext _context;
        public WritersController(ComicDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllWriters([FromQuery] QueryParameters parameters)
        {
            IQueryable<Writer> writers = _context.Writers;
            writers = writers
                .Skip(parameters.Size * (parameters.Page - 1))
                .Take(parameters.Size);
            return Ok(await writers.ToArrayAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Writer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWriterById(int id)
        {
            Writer? writer = await _context.Writers.FindAsync(id);
            return writer == null ? NotFound() : Ok(writer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateWriter(Writer writer)
        { 
            await _context.Writers.AddAsync(writer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWriterById), new { id = writer.Id }, writer);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateWriter(int id, Writer writer)
        {
            if (id != writer.Id) return BadRequest();

            _context.Entry(writer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWriter(int id)
        {
            Writer? writer = await _context.Writers.FindAsync(id);
            if(writer == null) return BadRequest();

            _context.Writers.Remove(writer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
