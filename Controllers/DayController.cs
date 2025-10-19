using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DayController: ControllerBase
{
    private readonly AppDbContext _context;
    public DayController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<List<Day>>> Get()
    {
        var days = await this._context.Day.ToListAsync();
        return Ok(days);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Day>> Get([FromRoute] int id)
    {
        var foundDay = await this._context.Day
            .FirstOrDefaultAsync(d => d.Id == id);
        if (foundDay == null)
        {
            return NotFound();
        }
        return Ok(foundDay);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DayDTO data)
    {
        var day = new Day { WeekDay = data.WeekDay };
        this._context.Day.Add(day);
        await this._context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] DayDTO data)
    {
        var foundDay = await this._context.Day
            .FirstOrDefaultAsync(d => d.Id == id);
        if (foundDay == null)
        {
            return NotFound();
        }
        foundDay.WeekDay = data.WeekDay;
        await this._context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var foundDay = await this._context.Day
            .FirstOrDefaultAsync(d => d.Id == id);
        if (foundDay == null)
        {
            return NotFound();
        }
        this._context.Day.Remove(foundDay);
        await this._context.SaveChangesAsync();
        
        return NoContent();
    }
}