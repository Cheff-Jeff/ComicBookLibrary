using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComicsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly ComicDbContext _context;
        public ComicController(ComicDbContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Comic>> Get()
            => await _context.Comics.ToListAsync();
    }
}
