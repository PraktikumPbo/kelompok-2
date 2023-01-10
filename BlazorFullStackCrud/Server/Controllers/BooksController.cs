using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Buku>>> GetSuperHeroes()
        {
            var heroes = await _context.Buku.ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<List<Genre>>> GetComics()
        {
            var genres = await _context.Genres.ToListAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Buku>> GetSingleHero(int id)
        {
            var hero = await _context.Buku
                .Include(h => h.Genre)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Shared.Buku>>> CreateSuperHero(Shared.Buku hero)
        {
            hero.Genre = null;
            _context.Buku.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Shared.Buku>>> UpdateSuperHero(Shared.Buku hero, int id)
        {
            var dbHero = await _context.Buku
                .Include(sh => sh.Genre  )
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no hero for you. :/");

            dbHero.Judul_Buku = hero.Judul_Buku;
            dbHero.Penerbit = hero.Penerbit;
            dbHero.Penulis = hero.Penulis;
            dbHero.GenreId = hero.GenreId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Shared.Buku>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.Buku
                .Include(sh => sh.Genre)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbHero == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Buku.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        private async Task<List<Shared.Buku>> GetDbHeroes()
        {
            return await _context.Buku.Include(sh => sh.Genre).ToListAsync();
        }
    }
}
