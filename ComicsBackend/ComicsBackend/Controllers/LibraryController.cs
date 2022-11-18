using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ComicDbContext _context;
        public LibraryController(ComicDbContext context) => _context = context;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parameters, int id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
            {
                IQueryable<Library> library = _context.libraries;
                library = library
                    .Where(u => u.UserId == id)
                    .Skip(parameters.Size * (parameters.Page - 1))
                    .Take(parameters.Size);

                return Ok(await library.ToArrayAsync());
            }
            return BadRequest("User not found");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Library), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Library? library = await _context.libraries
                .FirstOrDefaultAsync(e => e.Id == id);

            return library == null ? NotFound() : Ok(library);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Library library)
        { 
            _context.Entry(library).State = EntityState.Modified;

            await _context.libraries.AddAsync(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = library.Id }, library);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            Library? library = await _context.libraries.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }
            else 
            { 
                _context.libraries.Remove(library);
                await _context.SaveChangesAsync();
                
                return NoContent();
            }
        }
    }
}
