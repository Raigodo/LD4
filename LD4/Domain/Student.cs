using System.ComponentModel.DataAnnotations;

namespace LD4.Domain;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 20, MinimumLength = 3)]
    public required string Name { get; set; }

    public List<Course> Courses { get; set; } = [];
}