using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Data.Repositories.Implementation;

public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
{
    
    private readonly ApplicationDbContext context;
    public LectureRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}