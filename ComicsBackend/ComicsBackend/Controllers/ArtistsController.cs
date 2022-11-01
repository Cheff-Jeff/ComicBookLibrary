using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ComicDbContext _context;
        public ArtistsController(ComicDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllArtists([FromQuery] QueryParameters parameters)
        {
            IQueryable<Artist> artists= _context.Artists;
            artists = artists
                .Skip(parameters.Size * (parameters.Page - 1))
                .Take(parameters.Size);
            return Ok(await artists.ToArrayAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Artist), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWriterById(int id)
        {
            Artist? artist = await _context.Artists.FindAsync(id);
            return artist == null ? NotFound() : Ok(artist);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateWriter(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWriterById), new { id = artist.Id }, artist);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateWriter(int id, Artist artist)
        {
            if (id != artist.Id) return BadRequest();

            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWriter(int id)
        {
            Artist? artist = await _context.Artists.FindAsync(id);
            if (artist == null) return BadRequest();

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
