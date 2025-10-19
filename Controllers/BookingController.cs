using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/Department/{departmentId}/[controller]")]
public class BookingController: ControllerBase
{
    private readonly AppDbContext _context;
    public BookingController(AppDbContext context)
    {
        this._context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Booking>>> Get([FromRoute] int departmentId)
    {
        var bookings = await this._context.Booking
         .Where(b => b.DepartmentId == departmentId).ToListAsync();
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Booking>> Get([FromRoute] int departmentId, [FromRoute] int id)
    {
        var foundBooking = await this._context.Booking
            .FirstOrDefaultAsync(b => b.DepartmentId == departmentId && b.Id == id);
        if (foundBooking == null)
        {
            return NotFound();
        }
        return Ok(foundBooking);
    }

    [HttpPost]
    public async Task<ActionResult> Post(
        [FromRoute] int departmentId,
        [FromBody] BookingDTO data
    )
    {
        if (departmentId != data.DepartmentId)
        {
            return BadRequest();
        }
        var foundDepartment = await this._context
           .Department.FirstOrDefaultAsync(d => d.Id == data.DepartmentId);

        if (foundDepartment == null)
        {
            return NotFound();
        }
        var foundDoctor = await this._context.Doctor
            .FirstOrDefaultAsync(d => d.Id == data.DoctorId);

        if (foundDoctor == null) return NotFound();

        var booking = new Booking
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            EmailAddress = data.EmailAddress,
            PhoneNumber = data.PhoneNumber,
            SelectedDate = data.SelectedDate,
            SelectedTime = data.SelectedTime
        };
        if (data.MiddleName != null)
        {
            booking.MiddleName = data.MiddleName;
        }
        booking.Department = foundDepartment;
        booking.Doctor = foundDoctor;

        this._context.Booking.Add(booking);
        await this._context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{bookingId}")]
    public async Task<ActionResult> Delete([FromRoute] int departmentId, [FromRoute] int bookingId)
    {
        var booking = await this._context
          .Booking.FirstOrDefaultAsync(b => b.Id == bookingId && b.DepartmentId == departmentId);

        if (booking == null)
        {
            return NotFound();
        }
        this._context.Booking.Remove(booking);
        await this._context.SaveChangesAsync();

        return NoContent();
    }
}