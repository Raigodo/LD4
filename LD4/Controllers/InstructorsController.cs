using LD4.Data;
using LD4.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LD4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GelAll()
    {
        var instructors = await dbContext.Instructors
            .Include(x => x.Courses)
            .ToArrayAsync();
        return Results.Ok(instructors.ToResponseDto());
    }

    [HttpGet("{instructorId}")]
    public async Task<IResult> GelOne(int instructorId)
    {
        var instructor = await dbContext.Instructors
            .Include(x => x.Courses)
            .FirstOrDefaultAsync(s => s.Id == instructorId);
        if (instructor is null)
            return Results.NotFound();
        return Results.Ok(instructor.ToResponseDto());
    }

    public record CreateInstructorRequest(string Name, string Surname);
    [HttpPost]
    public async Task<IResult> Create(CreateInstructorRequest reqeust)
    {
        var instructor = new Instructor()
        {
            Name = reqeust.Name,
            Surname = reqeust.Surname,
            JoinedOn = DateOnly.FromDateTime(DateTime.UtcNow),
        };
        dbContext.Add(instructor);
        await dbContext.SaveChangesAsync();
        return Results.Ok(instructor.ToResponseDto());
    }

    [HttpDelete("{instructorId}")]
    public async Task<IResult> Delete(int instructorId)
    {
        var exists = await dbContext.Instructors.AnyAsync(x => x.Id == instructorId);
        if (!exists)
            return Results.NotFound();
        await dbContext.Instructors
            .Where(s => s.Id == instructorId)
            .ExecuteDeleteAsync();
        return Results.NoContent();
    }
    public record UpdateInstructorRequest(string? Name, string? Surname);

    [HttpPatch("{instructorId}")]
    public async Task<IResult> Update(
        int instructorId,
        UpdateInstructorRequest request)
    {
        var instructor = await dbContext.Instructors
            .Include(x => x.Courses)
            .FirstOrDefaultAsync(s => s.Id == instructorId);
        if (instructor is null)
            return Results.NotFound();
        if (request.Name is not null) instructor.Name = request.Name;
        if (request.Surname is not null) instructor.Surname = request.Surname;
        await dbContext.SaveChangesAsync();
        return Results.Ok(instructor.ToResponseDto());
    }
}
