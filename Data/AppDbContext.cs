using CliniqueBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Data;

public class AppDbContext: DbContext
{
    public DbSet<BlogPost> BlogPost { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Booking> Booking { get; set; }
    public DbSet<ContactMessage> ContactMessage { get; set; }
    public DbSet<Day> Day { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<EventSchedule> EventSchedule { get; set; }
    public DbSet<Fq> Fq { get; set; }
    public DbSet<Schedule> Schedule { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext>options): base(options){}
}