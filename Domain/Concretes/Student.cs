using Student_Managment.Domain.Commons;
using System.Text.Json.Serialization;

namespace Student_Managment.Domain.Concretes;

public class Student : BaseEntity
{
    public int Number { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string MiddleName { get; set; }

    // Navigation Properties
    [JsonIgnore]
    public virtual ICollection<Exam> Exams { get; set; }
    [JsonIgnore]
    public virtual ICollection<Lesson> Lessons { get; set; }
}
