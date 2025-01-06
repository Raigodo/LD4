using LD4.Data;
using LD4.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LD4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GelAll()
    {
        var students = await dbContext.Students
            .Include(x => x.Courses)
            .ToArrayAsync();
        return Results.Ok(students.ToResponseDto());
    }

    [HttpGet("{studentId}")]
    public async Task<IResult> GelOne(int studentId)
    {
        var student = await dbContext.Students
            .Include(x => x.Courses)
            .FirstOrDefaultAsync(s => s.Id == studentId);
        if (student is null)
            return Results.NotFound();
        return Results.Ok(student.ToResponseDto());
    }

    public record CreateStudentReqeust(string StudentName);
    [HttpPost]
    public async Task<IResult> Create(CreateStudentReqeust request)
    {
        var student = new Student()
        {
            Name = request.StudentName,
        };
        dbContext.Students.Add(student);
        await dbContext.SaveChangesAsync();
        return Results.Ok(student.ToResponseDto());
    }

    [HttpDelete("{studentId}")]
    public async Task<IResult> Delete(int studentId)
    {
        var exists = await dbContext.Students.AnyAsync(x => x.Id == studentId);
        if (!exists)
            return Results.NotFound();
        await dbContext.Students
            .Where(s => s.Id == studentId)
            .ExecuteDeleteAsync();
        return Results.NoContent();
    }

    public record UpdateStudentReqeust(string? StudentName);
    [HttpPatch("{studentId}")]
    public async Task<IResult> Update(
        int studentId,
        UpdateStudentReqeust reqeust)
    {
        var student = await dbContext.Students
            .Include(x => x.Courses)
            .FirstOrDefaultAsync(s => s.Id == studentId);
        if (student is null)
            return Results.NotFound();
        if (reqeust.StudentName is not null) student.Name = reqeust.StudentName;
        await dbContext.SaveChangesAsync();
        return Results.Ok(student.ToResponseDto());
    }
}
