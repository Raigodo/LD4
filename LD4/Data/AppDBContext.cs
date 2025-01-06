using LD4.Domain;
using Microsoft.EntityFrameworkCore;

namespace LD4.Data;

public class AppDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=Data\\Database\\localdb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Instructor>()
            .Property(i => i.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Student>()
            .Property(s => s.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Course>()
            .HasOne(x => x.Instructor)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.InstructorId)
            .OnDelete(DeleteBehavior.SetNull);

        var instructors = new Instructor[]
        {
            new()
            {
                Id = 1,
                Name = "Instruktors 1",
                Surname = "aaaaaaaaaaa",
                JoinedOn = new DateOnly(day:7, month:7, year:2001)
            },
            new()
            {
                Id = 2,
                Name = "Instruktors 2",
                Surname = "bbbbbbbbbbbbbbb",
                JoinedOn = new DateOnly(day:1, month:12, year:2010)
            },
        };
        var courses = new Course[]
        {
            new()
            {
                Id= 1,
                Topic = "why 2 + 2 != 4",
                StartingAt = new DateTime(),
                EndingAt = new DateTime().AddHours(1.5),
                InstructorId = instructors[0].Id,
            },
            new() {
                Id = 2,
                Topic = "why 2 + 2 != 4",
                StartingAt = DateTime.Now,
                EndingAt = DateTime.Now.AddHours(1.5),
                InstructorId = instructors[0].Id,
            },
            new() {
                Id = 3,
                Topic = "Introduction to Quantum Mechanics",
                StartingAt = DateTime.Now.AddDays(1),
                EndingAt = DateTime.Now.AddDays(1).AddHours(2),
                InstructorId = instructors[0].Id,
            },
            new() {
                Id = 4,
                Topic = "Advanced Mathematics",
                StartingAt = DateTime.Now.AddDays(2),
                EndingAt = DateTime.Now.AddDays(2).AddHours(1.5),
                InstructorId = instructors[0].Id,
            },
            new() {
                Id = 5,
                Topic = "Philosophy of Science",
                StartingAt = DateTime.Now.AddDays(3),
                EndingAt = DateTime.Now.AddDays(3).AddHours(2),
                InstructorId = instructors[1].Id
            },
            new() {
                Id = 6,
                Topic = "History of Art",
                StartingAt = DateTime.Now.AddDays(4),
                EndingAt = DateTime.Now.AddDays(4).AddHours(1.5),
                InstructorId = instructors[1].Id
            }
        };

        var students = new Student[]
        {
            new()
            {
                Id = 1,
                Name = "pirmais",
            },
            new()
            {
                Id = 2,
                Name = "otrais",
            },
            new()
            {
                Id = 3,
                Name = "tresais",
            },
        };

        modelBuilder.Entity<Instructor>().HasData(instructors);
        modelBuilder.Entity<Course>().HasData(courses);
        modelBuilder.Entity<Student>().HasData(students);
    }
}