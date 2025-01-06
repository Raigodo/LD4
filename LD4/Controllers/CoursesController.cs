using LD4.Data;
using LD4.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LD4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAll()
    {
        var courses = await dbContext.Courses
            .Include(x => x.Instructor)
            .Include(x => x.Students)
            .ToArrayAsync();
        return Results.Ok(courses.ToResponseDto());
    }

    [HttpGet("{courseId}")]
    public async Task<IResult> GetOne(int courseId)
    {
        var course = await dbContext.Courses
            .Include(x => x.Instructor)
            .Include(x => x.Students)
            .FirstOrDefaultAsync(s => s.Id == courseId);
        if (course is null)
            return Results.NotFound();
        return Results.Ok(course.ToResponseDto());
    }

    public record CreateCourseRequest(string Topic, int InstructorId);
    [HttpPost]
    public async Task<IResult> CreateStudent(CreateCourseRequest request)
    {
        var course = new Course()
        {
            Topic = request.Topic,
            InstructorId = request.InstructorId
        };
        dbContext.Add(course);
        await dbContext.SaveChangesAsync();
        return Results.Ok(course.ToResponseDto());
    }

    [HttpDelete("{courseId}")]
    public async Task<IResult> DeleteStudent(int courseId)
    {
        var exists = await dbContext.Courses.AnyAsync(x => x.Id == courseId);
        if (!exists)
            return Results.NotFound();
        await dbContext.Courses
            .Where(s => s.Id == courseId)
            .ExecuteDeleteAsync();
        return Results.NoContent();
    }

    public record UpdateCourseRequest(string? Topic, int? InstructorId);
    [HttpPatch("{courseId}")]
    public async Task<IResult> UpdateStudent(
        int courseId,
        UpdateCourseRequest request)
    {
        var course = await dbContext.Courses
            .Include(x => x.Instructor)
            .Include(x => x.Students)
            .FirstOrDefaultAsync(s => s.Id == courseId);
        if (course is null)
            return Results.NotFound();
        if (request.Topic is not null) course.Topic = request.Topic;
        if (request.InstructorId is not null) course.InstructorId = request.InstructorId.Value;
        await dbContext.SaveChangesAsync();
        return Results.Ok(course.ToResponseDto());
    }

    public record AddStudentCourseRequest(int StudentId);
    [HttpPost("{courseId}/students")]
    public async Task<IResult> AddStudent(
        int courseId,
        AddStudentCourseRequest request)
    {
        var course = await dbContext.Courses
            .Include(x => x.Instructor)
            .Include(x => x.Students)
            .FirstOrDefaultAsync(s => s.Id == courseId);
        if (course is null)
            return Results.NotFound();
        var student = await dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == request.StudentId);
        if (student is null)
            return Results.NotFound();
        if (!course.Students.Any(x => x.Id == student.Id)) course.Students.Add(student);
        await dbContext.SaveChangesAsync();
        return Results.Ok(course.ToResponseDto());
    }

    [HttpDelete("{courseId}/students/{studentId}")]
    public async Task<IResult> AddStudent(
        int courseId,
        int studentId)
    {
        var course = await dbContext.Courses
            .Include(x => x.Instructor)
            .Include(x => x.Students)
            .FirstOrDefaultAsync(s => s.Id == courseId);
        if (course is null)
            return Results.NotFound();
        course.Students.RemoveAll(x => x.Id == studentId);
        await dbContext.SaveChangesAsync();
        return Results.Ok(course.ToResponseDto());
    }
}
