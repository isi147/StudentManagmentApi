using Student_Managment.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Student_Managment.Domain.Concretes;

public class Exam : BaseEntity
{
    public DateTime ExamDate { get; set; }
    public int Mark { get; set; }

    // Foreign Key
    public int StudentId { get; set; }

    // Navigation Properties
    [JsonIgnore]
    [ForeignKey(nameof(StudentId))]
    public virtual Student Student { get; set; }

    [JsonIgnore]
    public virtual Lesson Lesson { get; set; }
}
