using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Data.Repositories.Implementation;

public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
{
    private readonly ApplicationDbContext context;
    public AttendanceRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
    
}