using E_Attend.Data_Access.context;
using E_Attend.Entities.Models;
using E_Attend.Entities.Repositories;

namespace E_Attend.Data_Access.RepositoryImplementation
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        private readonly ApplicationDbContext context;
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
