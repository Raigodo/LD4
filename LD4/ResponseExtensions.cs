using LD4.Domain;

namespace LD4;

public static class ResponseExtensions
{
    public static object ToResponseDto(this IEnumerable<Student> students) => students.Select(x => x.ToResponseDto());
    public static object ToResponseDto(this IEnumerable<Instructor> instructors) => instructors.Select(x => x.ToResponseDto());
    public static object ToResponseDto(this IEnumerable<Course> courses) => courses.Select(x => x.ToResponseDto());

    public static object ToResponseDto(this Student student)
    {
        return new
        {
            Id = student.Id,
            Name = student.Name,
            Courses = student.Courses?.ToDto() ?? Array.Empty<object>(),
        };
    }
    public static object ToResponseDto(this Instructor instructor)
    {
        return new
        {
            Id = instructor.Id,
            Name = instructor.Name,
            Surname = instructor.Surname,
            JoinedOn = instructor.JoinedOn,
            Courses = instructor.Courses?.ToDto() ?? Array.Empty<object>(),
        };
    }

    public static object ToResponseDto(this Course course)
    {
        return new
        {
            Id = course.Id,
            Topic = course.Topic,
            Instructor = course.Instructor?.ToDto(),
            Students = course.Students?.ToDto() ?? Array.Empty<object>(),
        };
    }



    public static object ToDto(this IEnumerable<Student> students) => students.Select(x => x.ToDto());
    public static object ToDto(this IEnumerable<Instructor> instructors) => instructors.Select(x => x.ToDto());
    public static object ToDto(this IEnumerable<Course> courses) => courses.Select(x => x.ToDto());

    private static object ToDto(this Student student)
    {
        return new
        {
            Id = student.Id,
            Name = student.Name,
        };
    }
    private static object ToDto(this Instructor instructor)
    {
        return new
        {
            Id = instructor.Id,
            Name = instructor.Name,
            Surname = instructor.Surname,
            JoinedOn = instructor.JoinedOn,
        };
    }

    private static object ToDto(this Course course)
    {
        return new
        {
            Id = course.Id,
            Topic = course.Topic,
        };
    }
}
