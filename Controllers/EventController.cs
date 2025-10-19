using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EventController: ControllerBase
{
    private readonly AppDbContext _context;
    public EventController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<Event>> Get()
    {
        var events = await this._context.Event
        .Include(e => e.Schedules)
        .ToListAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> Get([FromRoute] int id)
    {
        var foundEvent = await this._context
            .Event
            .Include(e => e.Schedules)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (foundEvent == null)
        {
            return NotFound();
        }
        return Ok(foundEvent);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] EventDTO data)
    {
        var department = await this._context
            .Department.FirstOrDefaultAsync(d => d.Id == data.DepartmentId);
        if (department == null)
        {
            return NotFound();
        }
        var newEvent = new Event
        {
            Title = data.Title,
            Description = data.Description,
            PersonInCharge = data.PersonInCharge
        };
        newEvent.Department = department;
        this._context.Event.Add(newEvent);

        await this._context.SaveChangesAsync();
        if(data.Schedules.Count > 0)
        {
            var foundEvent = await this._context.Event
            .FirstOrDefaultAsync(e => e.Title == data.Title
            && e.Description == data.Description);

            if(foundEvent == null){
                return BadRequest();
            }
            List<EventSchedule> schedules = new List<EventSchedule>();
            foreach(EventScheduleDTO schedule in data.Schedules)
            {
                var eventSchedule = new EventSchedule
                {
                    Date = schedule.Date,
                    StartHour = schedule.StartHour,
                    EndHour = schedule.EndHour
                };
                eventSchedule.Event = foundEvent;
                this._context.EventSchedule.Add(eventSchedule);
            };
            await this._context.SaveChangesAsync();
        }
        return NoContent();
    }

    [HttpGet]
    [Route("/api/[controller]/all")]
    public async Task<ActionResult<Event>> GetAll()
    {
        var result = await this._context.Event
         .Include(e => e.Schedules)
         .ToListAsync();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] EventDTO data)
    {

        var department = await this._context
            .Department.FirstOrDefaultAsync(d => d.Id == data.DepartmentId);
        if (department == null)
        {
            return NotFound();
        }
        var foundEvent = await this._context
            .Event
            .Include(e => e.Schedules)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (foundEvent == null)
        {
            return NotFound();
        }
        foundEvent.Title = data.Title;
        foundEvent.Description = data.Description;
        foundEvent.PersonInCharge = data.PersonInCharge;
        foundEvent.Department = department;

        if (data.Schedules.Count < foundEvent.Schedules.Count)
        {
            var ids = (from s in data.Schedules
                       select s.ScheduleId).ToList();
            var schedulesToDelete = foundEvent.Schedules
            .Where(s => !ids.Contains(s.Id)).ToList();

            this._context.EventSchedule.RemoveRange(schedulesToDelete);
        }
        // every event must have at least one schedule
        if(data.Schedules.Count == 0)
        {
            return BadRequest();
        }
        if(data.Schedules.Count > 0)
        {
            foreach(EventScheduleDTO element in data.Schedules)
            {
                if (element.ScheduleId == 0)
                {
                    var schedule = new EventSchedule
                    {
                        Date = element.Date,
                        StartHour = element.StartHour,
                        EndHour = element.EndHour
                    };
                    schedule.Event = foundEvent;
                    this._context.EventSchedule.Add(schedule);
                    continue;
                }
                
                var selectSchedule = foundEvent.Schedules
                .Where(s => s.Id == element.ScheduleId)
                .SingleOrDefault();

                if (selectSchedule == null)
                {
                    return BadRequest();
                }
                selectSchedule.Date = element.Date;
                selectSchedule.StartHour = element.StartHour;
                selectSchedule.EndHour = element.EndHour;
            }
        }

        await this._context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var foundEvent = await this._context
            .Event.FirstOrDefaultAsync(e => e.Id == id);
        if (foundEvent == null)
        {
            return NotFound();
        }
        this._context.Event.Remove(foundEvent);
        await this._context.SaveChangesAsync();

        return NoContent();
    }
}