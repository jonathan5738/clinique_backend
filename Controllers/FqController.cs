using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class FqController: ControllerBase
{
    private readonly AppDbContext _context;
    public FqController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<List<Fq>>> Get()
    {
        var fqs = await this._context.Fq.ToListAsync();
        return Ok(fqs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fq>> Get([FromRoute] int id)
    {
        var foundFq = await this._context
            .Fq.FirstOrDefaultAsync(f => f.Id == id);
        if (foundFq == null)
        {
            return NotFound();
        }
        return Ok(foundFq);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] FqDTO data)
    {
        var fq = new Fq { Question = data.Question, Answer = data.Answer };
        this._context.Fq.Add(fq);
        await this._context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] FqDTO data)
    {
        var foundFq = await this._context
            .Fq.FirstOrDefaultAsync(f => f.Id == id);
        if (foundFq == null)
        {
            return NotFound();
        }
        foundFq.Answer = data.Answer;
        foundFq.Question = data.Question;

        await this._context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var foundFq = await this._context
            .Fq.FirstOrDefaultAsync(fq => fq.Id == id);
        if (foundFq == null)
        {
            return NotFound();
        }
        this._context.Fq.Remove(foundFq);
        await this._context.SaveChangesAsync();

        return NoContent();
    }
}