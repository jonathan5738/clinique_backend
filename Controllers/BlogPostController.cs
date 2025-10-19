using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BlogPostController: ControllerBase
{
    private readonly AppDbContext _context;
    public BlogPostController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<List<BlogPost>>> Get()
    {
        var blogPosts = await this._context
            .BlogPost.OrderByDescending(b => b.CreatedAt)
            .ToListAsync();

        return Ok(blogPosts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost>> Get([FromRoute] int id)
    {
        var foundBlogPost = await this._context.BlogPost
           .FirstOrDefaultAsync(b => b.Id == id);
        if (foundBlogPost == null)
        {
            return NotFound();
        }
        return Ok(foundBlogPost);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] BlogPostDTO data)
    {

        var foundDepartment = await this._context
          .Department.FirstOrDefaultAsync(d => d.Id == data.DepartmentId);
        if (foundDepartment == null)
        {
            return NotFound();
        }
        var blogPost = new BlogPost { Content = data.Content, Author = data.Author };
        blogPost.Department = foundDepartment;

        this._context.BlogPost.Add(blogPost);
        await this._context.SaveChangesAsync();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] BlogPostDTO data)
    {

        var foundBlogPost = await this._context.BlogPost
           .FirstOrDefaultAsync(b => b.Id == id);
        if (foundBlogPost == null)
        {
            return NotFound();
        }
        var foundDepartment = await this._context
          .Department.FirstOrDefaultAsync(d => d.Id == data.DepartmentId);
        if (foundDepartment == null)
        {
            return NotFound();
        }
        foundBlogPost.Content = data.Content;
        foundBlogPost.Author = data.Author;
        foundBlogPost.Department = foundDepartment;

        await this._context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {

        var foundBlogPost = await this._context.BlogPost
           .FirstOrDefaultAsync(b => b.Id == id);
        if (foundBlogPost == null)
        {
            return NotFound();
        }
        this._context.BlogPost.Remove(foundBlogPost);
        await this._context.SaveChangesAsync();
        return Ok();
    }
}