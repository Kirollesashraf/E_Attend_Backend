using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Data.Repositories.Implementation;

public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
{
    private readonly ApplicationDbContext context;
    public InstructorRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
    
}