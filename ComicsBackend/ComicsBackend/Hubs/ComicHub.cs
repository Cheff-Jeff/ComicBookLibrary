using Microsoft.AspNetCore.SignalR;
using ComicsBackend.Data;
using ComicsBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ComicsBackend.Hubs
{
    public class ComicHub : Hub
    {
        private readonly ComicDbContext _context;
        public ComicHub(ComicDbContext context) 
            => _context = context;

        public async Task AddPopularity(int comicId)
        {
            Comic? comic = await _context.Comics
                .Include(c => c.Writer)
                .Include(c => c.Publisher)
                .Include(c => c.Artist)
                .Include(c => c.CoverArtist)
                .FirstOrDefaultAsync(e => e.Id == comicId);

            if (comic != null)
            {
                comic.Popularity++;

                _context.Entry(comic).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            List<Comic> comics = await _context.Comics.OrderByDescending(c => c.Popularity).Take(10).ToListAsync();
            var data = JsonSerializer.Serialize(comics);
            await Clients.All.SendAsync("RecivePopular",data);
        }
    }
}
