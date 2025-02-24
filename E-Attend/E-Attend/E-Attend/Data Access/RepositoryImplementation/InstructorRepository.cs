using E_Attend.Data_Access.context;
using E_Attend.Entities.Models;
using E_Attend.Entities.Repositories;

namespace E_Attend.Data_Access.RepositoryImplementation
{
<<<<<<<< HEAD:E-Attend/E-Attend/E-Attend/Data Access/RepositoryImplementation/instructorRepository.cs
    public class instructorRepository : GenericRepository<instructor>, IInstructorRepository
    {
        private readonly ApplicationDbContext context;
        public instructorRepository(ApplicationDbContext context) : base(context)
========
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        private readonly ApplicationDbContext context;
        public InstructorRepository(ApplicationDbContext context) : base(context)
>>>>>>>> MainServices:E-Attend/E-Attend/E-Attend/Data Access/RepositoryImplementation/InstructorRepository.cs
        {
            this.context = context;
        }
    }
}
