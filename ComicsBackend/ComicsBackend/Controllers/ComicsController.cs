﻿using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicDbContext _context;
        public ComicsController(ComicDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllComics([FromQuery] QueryParameters parameters)
        {
            IQueryable<Comic> comics = _context.Comics;
            comics = comics
                .OrderByDescending(c => c.Id)
                .Skip(parameters.Size * (parameters.Page - 1))
                .Take(parameters.Size);


            return Ok(await comics.ToArrayAsync());
        }

        [HttpGet]
        [Route("PopularComics")]
        public async Task<IActionResult> GetPupularComics()
        { 
            IQueryable<Comic> comics = _context.Comics;
            comics = comics.OrderByDescending(c => c.Popularity).Take(10);

            return Ok(await comics.ToArrayAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Comic), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            Comic? comic = await _context.Comics
                .Include(c => c.Writer)
                .Include(c => c.Publisher)
                .Include(c => c.Artist)
                .Include(c => c.CoverArtist)
                .FirstOrDefaultAsync(e => e.Id == id);

            return comic == null ? NotFound() : Ok(comic);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromForm] Comic comic)
        {
            _context.Entry(comic).State = EntityState.Modified;

            await comic.UploadImageAsync();

            await _context.Comics.AddAsync(comic);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = comic.Id }, comic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromForm] Comic comic)
        {
            if (id != comic.Id)
            {
                return BadRequest();
            }
            else 
            {
                _context.Entry(comic).State = EntityState.Modified;

                if (comic.ImageFile != null)
                {
                    await comic.UploadImageAsync();
                }

                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        { 
            Comic? comic = await _context.Comics.FindAsync(id);
            if (comic == null)
            {
                return NotFound();
            }
            else
            { 
                _context.Comics.Remove(comic);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
