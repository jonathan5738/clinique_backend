using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EventScheduleController : ControllerBase
{
    private readonly AppDbContext _context;
    public EventScheduleController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<EventSchedule>> Get()
    {
        var schedules = await this._context
            .EventSchedule.ToListAsync();
        return Ok(schedules);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EventScheduleDTO data)
    {
        var foundEvent = await this._context
            .Event.FirstOrDefaultAsync(e => e.Id == data.EventId);
        if (foundEvent == null)
        {
            return NotFound();
        }
        var eventSchedule = new EventSchedule
        {
            Date = data.Date,
            StartHour = data.StartHour,
            EndHour = data.EndHour
        };
        eventSchedule.Event = foundEvent;
        this._context.EventSchedule.Add(eventSchedule);
        await this._context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] EventSchedule data)
    {
        var foundEventSchedule = await this._context.EventSchedule
            .FirstOrDefaultAsync(e => e.Id == id && e.EventId == data.EventId);

        if (foundEventSchedule == null)
        {
            return NotFound();
        }
        foundEventSchedule.Date = data.Date;
        foundEventSchedule.StartHour = data.StartHour;
        foundEventSchedule.EndHour = data.EndHour;

        await this._context.SaveChangesAsync();

        return NoContent();
    }
}