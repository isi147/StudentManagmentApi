using Student_Managment.Domain.Commons;
using System.Text.Json.Serialization;

namespace Student_Managment.Domain.Concretes;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public int Number { get; set; }

    // Navigation Properties
    [JsonIgnore]
    public virtual ICollection<Lesson> Lessons { get; set; }
}
