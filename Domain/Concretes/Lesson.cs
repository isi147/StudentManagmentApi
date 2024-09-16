using Student_Managment.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student_Managment.Domain.Concretes;

public class Lesson : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }

    // Foreign Key
    public int ExamId { get; set; }

    // Navigation Properties
    [JsonIgnore]
    public virtual ICollection<Student> Students { get; set; }
    [JsonIgnore]
    public virtual ICollection<Group> Groups { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(ExamId))]
    public virtual Exam Exam { get; set; }
}
