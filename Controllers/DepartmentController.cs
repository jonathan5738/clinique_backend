using CliniqueBackend.Data;
using CliniqueBackend.Dtos;
using CliniqueBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DepartmentController: ControllerBase
{
    private readonly AppDbContext _context;
    public DepartmentController(AppDbContext context) => this._context = context;

    [HttpGet]
    public async Task<ActionResult<List<Department>>> Get()
    {
        var departments = await this._context.Department.ToListAsync();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> Get([FromRoute] int id)
    {
        var department = await this._context.Department.FirstOrDefaultAsync(d => d.Id == id);
        if (department == null) return NotFound();
        return Ok(department);
    }

    [HttpGet]
    [Route("/api/[controller]/all")]
    public async Task<ActionResult<Department>> GetAll()
    {
        var result = await this._context.Department
             .Include(department => department.Doctors)
             .ThenInclude(doctor => doctor.Schedules)
             .ToListAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] DepartmentDTO data)
    {
        var department = new Department { Name = data.Name };
        this._context.Department.Add(department);
        await this._context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put([FromRoute] int id, [FromBody] DepartmentDTO data)
    {
        var foundDepartment = await this._context.Department.FirstOrDefaultAsync(d => d.Id == id);
        if (foundDepartment == null)
        {
            return NotFound();
        }
        foundDepartment.Name = data.Name;
        await this._context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult>Delete([FromRoute] int id)
    {

        var foundDepartment = await this._context
            .Department.FirstOrDefaultAsync(d => d.Id == id);
        if (foundDepartment == null)
        {
            return NotFound();
        }
        this._context.Department.Remove(foundDepartment);
        await this._context.SaveChangesAsync();
        return NoContent();
    }
}