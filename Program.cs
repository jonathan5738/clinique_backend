using System.Text.Json.Serialization;
using CliniqueBackend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions
      .ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<AppDbContext>(options => options
  .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
[Table("blogs")]
public class Blog 
{
    public int Id {get; set;}
    public string Name {get; set;}

    // nagivate property
    public List<Post> Posts {get;set;}
}

[Table("blogs")]
public class Post 
{
    [Column("id")]
    publit int Id {get; set;}

    [Column("title")]
    public string Title {get; set;}

    [Column("content")]
    public string Content {get; set;}

    [Column("blog_id")]
    public int BlogId {get; set;}
    public Blog Blog {get; set;}
}

public class AppDbContext: DbContext 
{
    public DbSet<Blog> Blog {get;set;}
    public AppDbContext(DbContextOptions<AppDbContext>options): base(options){}
}

int[] numbers = {12, 34,1, 46, 38, 19};
IEnumerable<int> result = 
    from number in numbers
    where numer % 2 == 0
    select number;

int count = result.Count();

var query = from number in numbers
where number <= 40
orderby number descending
select number;

var query = 
    from number in numbers
    where number >= 50
    select $"The score is ${number}";
*/



/*
public class Department 
{
    public int Id {get; set;}
    public string Name {get; set;}

    public ICollection<Doctor> Doctors {get; set;} = new List<Doctor>();
}

public class Doctor 
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string? MiddleNamen {get; set;}

    public int DepartmentId {get; set;}
    public Department Department {get; set;}

    public ICollection<Schedule> Schedules {get; set;} = new List<Schedule>();
}

public class Schedule 
{
    public int Id {get; set;}
    public string Day {get; set;}

    [Column("start_hour")]
    public string StartHour {get; set;}

    [Column("end_hour")]
    public string EndHour {get; set;}

    public int DoctorId {get; set;}
    public Doctor Doctor {get; set;}
}
*/