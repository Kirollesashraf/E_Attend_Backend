using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Data.Repositories.Implementation;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    
    private readonly ApplicationDbContext context;
    public CourseRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}