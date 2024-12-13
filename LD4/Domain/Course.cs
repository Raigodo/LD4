using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LD4.Domain;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(maximumLength: 100, MinimumLength = 3)]
    public required string Topic { get; set; }

    [Required]
    public DateTime StartingAt { get; set; }
    [Required]
    public DateTime EndingAt { get; set; }

    [Required]
    [ForeignKey(nameof(Instructor))]
    public required int InstructorId { get; set; }

    [JsonIgnore]
    public Instructor Instructor { get; }

    [JsonIgnore]
    public List<Student> Students { get; }
}