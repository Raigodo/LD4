using LD4.Data;
using LD4.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/students", async (AppDbContext dbContext) =>
{
    var students = await dbContext.Students.ToArrayAsync();
    return Results.Ok(students);
});

app.MapGet("/students/{studentId}", async (int studentId, AppDbContext dbContext) =>
{
    var student = await dbContext.Students
        .FirstOrDefaultAsync(s => s.Id == studentId);
    return Results.Ok(student);
});

app.MapPost("/students", async ([FromBody] string studentName, AppDbContext dbContext) =>
{
    var student = new Student()
    {
        Name = studentName,
    };
    dbContext.Students.Add(student);
    await dbContext.SaveChangesAsync();
    return Results.Ok(student);
});

app.MapDelete("/students/{studentId}", async (int studentId, AppDbContext dbContext) =>
{
    await dbContext.Students
        .Where(s => s.Id == studentId)
        .ExecuteDeleteAsync();
    return Results.NoContent();
});

app.MapPatch("/students/{studentId}", async (
    int studentId,
    [FromBody] string studentName, 
    AppDbContext dbContext) =>
{
    var student = await dbContext.Students
        .FirstOrDefaultAsync(s => s.Id == studentId);

    if (student is null)
        return Results.NotFound();

    student.Name = studentName;

    dbContext.Update(student);
    await dbContext.SaveChangesAsync();

    return Results.Ok(student);
});

app.Run();