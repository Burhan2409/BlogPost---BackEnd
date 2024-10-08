using Microsoft.AspNetCore.Mvc;
using MiniProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase

    {
        private readonly InboxContext context;

        public PostsController(InboxContext _context)
        {
            context = _context;
        }

        [HttpGet("posts")]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
        {
            return await context.Burhan_Post.ToListAsync();
        }

        [HttpGet("{UserId}")]
        public async Task<ActionResult<IEnumerable<Posts>>> GetPosts(int UserId)
        {
            return await context.Burhan_Post.Where(p => p.UserId == UserId).ToListAsync();
        }

        [HttpPut("{postId}")]
        public async Task<IActionResult> UpdatePost(int postId, [FromBody] Posts updatedPost)
        {
            var post = await context.Burhan_Post.FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                return NotFound();
            }

            post.PostDescription = updatedPost.PostDescription;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Failed to update the post");
            }

            return Ok(post);
        }

        [HttpDelete("{PostId}")]
        public async Task<IActionResult> DeletePost(int PostId)
        {
            var post = await context.Burhan_Post.FindAsync(PostId);
            if (post == null)
            {
                return NotFound();
            }

            context.Burhan_Post.Remove(post);
            await context.SaveChangesAsync();

            return Ok(post);
        }

        [HttpPost("addPost")]
        public void AddFeed([FromBody] Posts formdata)
        {
            var lastPostId = context.Burhan_Post.OrderByDescending(u => u.PostId).FirstOrDefault();
            Posts newPost = new Posts()
            {
                PostId = 0,
                UserId = formdata.UserId,
                Title = formdata.Title,
                PostDescription = formdata.PostDescription
            };
            context.Burhan_Post.Add(newPost);
            context.SaveChanges();
        }

        [HttpPut("updateFeed")]
        public void UpdateFeed([FromBody] Posts formdata)
        {
            var findPost = context.Burhan_Post.Find(formdata.PostId);
            findPost.Title = formdata.Title;
            findPost.PostDescription = formdata.PostDescription;
            context.Burhan_Post.Update(findPost);
            context.SaveChanges();
        }
    }

   
}
