using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ContactMessageController: ControllerBase
{
    private readonly AppDbContext _context;
    public ContactMessageController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<List<ContactMessage>>> Get()
    {
        var contactMessages = await this._context
            .ContactMessage
            .OrderByDescending(c => c.CreatedAt).ToListAsync();
        return Ok(contactMessages);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactMessage>> Get([FromRoute] int id)
    {
        var contactMessage = await this._context.ContactMessage
            .FirstOrDefaultAsync(c => c.Id == id);
        if (contactMessage == null)
        {
            return NotFound();
        }
        return Ok(contactMessage);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ContactMessageDTO data)
    {
        var message = new ContactMessage
        {
            FirstName = data.FirstName,
            LastName = data.LastName,
            Title = data.Title,
            Content = data.Content,
            PhoneNumber = data.PhoneNumber,
            EmailAddress = data.EmailAddress
        };
        if (data.MiddleName != null)
        {
            message.MiddleName = data.MiddleName;
        }
        this._context.ContactMessage.Add(message);
        await this._context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var contactMessage = await this._context.ContactMessage
            .FirstOrDefaultAsync(c => c.Id == id);
        if (contactMessage == null)
        {
            return NotFound();
        }
        this._context.ContactMessage.Remove(contactMessage);
        await this._context.SaveChangesAsync();

        return Ok();
    }
}