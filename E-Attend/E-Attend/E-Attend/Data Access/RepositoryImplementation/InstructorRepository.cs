using E_Attend.Data_Access.context;
using E_Attend.Entities.Models;
using E_Attend.Entities.Repositories;

namespace E_Attend.Data_Access.RepositoryImplementation
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly ApplicationDbContext context;
        public InstructorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
