using Grits.Server.Data;
using Grits.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Grits.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeveloperController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _context.Articles.ToListAsync();
            return Ok(posts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSinglePost(int id)
        {
            var dev = await _context.Articles.FirstOrDefaultAsync(a => a.ID == id);
            return Ok(dev);
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            _context.Add(article);
            await _context.SaveChangesAsync();
            return Ok(article.ID);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var dev = new Article { ID = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

