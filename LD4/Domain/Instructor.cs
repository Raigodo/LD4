using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LD4.Domain;

public class Instructor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 20, MinimumLength = 3)]
    public required string Name { get; set; }

    [Required]
    [StringLength(maximumLength: 20, MinimumLength = 3)]
    public required string Surname { get; set; }

    [Required]
    public DateOnly JoinedOn { get; set; }

    public List<Course> Courses { get; } = [];
}