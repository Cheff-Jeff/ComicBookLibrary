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

        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parameters, int userId)
        {
            if (!String.IsNullOrEmpty(userId.ToString()))
            {
                IQueryable<Library> library = _context.libraries;
                library = library
                    .Where(u => u.UserId == userId)
                    .Include(c => c.Comic)
                    .Skip(parameters.Size * (parameters.Page - 1))
                    .Take(parameters.Size);

                return Ok(await library.ToArrayAsync());
            }
            return BadRequest("User not found");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Library library)
        {
            _context.Entry(library).State = EntityState.Modified;

            await _context.libraries.AddAsync(library);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = library.Id }, library);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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

        [HttpGet]
        [Route("GetOneItem")]
        [ProducesResponseType(typeof(Library), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Library? library = await _context.libraries
                .Include(c => c.Comic)
                .FirstOrDefaultAsync(e => e.Id == id);

            return library == null ? NotFound() : Ok(library);
        }
    }
}
