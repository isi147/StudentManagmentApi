using Student_Managment.Domain.Concretes;

namespace Student_Managment.Aplication.Repositories;

public interface IGroupRepository:IGenericRepository<Group>
{
    Task<Group?> GetByIdWithLessonsAsync(int id);
}
