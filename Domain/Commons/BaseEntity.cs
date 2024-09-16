
namespace Student_Managment.Domain.Commons;

public abstract class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
