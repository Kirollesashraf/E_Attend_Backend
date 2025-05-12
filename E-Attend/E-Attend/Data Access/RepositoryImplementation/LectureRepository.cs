using E_Attend.Data_Access.context;
using E_Attend.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Attend.Data_Access.RepositoryImplementation;

namespace E_Attend.Domain.Repositories
{
    public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
    {
        private readonly ApplicationDbContext _context;

        public LectureRepository(ApplicationDbContext context) : base(context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

    }
}
