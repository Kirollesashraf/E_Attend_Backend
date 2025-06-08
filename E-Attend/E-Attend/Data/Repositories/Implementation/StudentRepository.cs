using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Data.Repositories.Implementation;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly ApplicationDbContext context;
    public StudentRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}