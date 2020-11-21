using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blogmenia.Core;
using Blogmenia.Data;
using Microsoft.AspNetCore.Authorization;

namespace Blogmenia.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogmeniaDbContext _context;
        private readonly IRepositoryData repositoryData;

        public PostsController(BlogmeniaDbContext context, IRepositoryData repositoryData)
        {
            _context = context;
            this.repositoryData = repositoryData;
        }

        // GET: api/Posts
        [HttpGet]
        [Route("AllPost")]
        [ValidateAntiForgeryToken]
        public   ActionResult<IEnumerable<Post>> GetPost()
        {
            return repositoryData.GetAllPost().ToList();
            
        }

        [HttpGet]
        [Route("AllLatestPost")]
        [ValidateAntiForgeryToken]
        public ActionResult<IEnumerable<Post>> GetLatestPost()
        {
            return repositoryData.GetLatestPost().ToList();

        }

        // GET: api/Posts
        [HttpGet]
        [Route("DemoList")]
        [ValidateAntiForgeryToken]
        public ActionResult<IEnumerable<Demos>> GetDemoList()
        {
            return repositoryData.GetAllDemoList().ToList();

        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await repositoryData.GetPostById_Async(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
