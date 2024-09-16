using Microsoft.EntityFrameworkCore;
using Student_Managment.Aplication.Repositories;
using Student_Managment.Domain.Concretes;
using Student_Managment.Persistence.Context;

namespace Student_Managment.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(StudentManagmentDbContext context) : base(context)
    {
    }

    public async Task<Group?> GetByIdWithLessonsAsync(int id)
    {
        var group = await _context.Groups.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == id);
        return group;
    }
}
