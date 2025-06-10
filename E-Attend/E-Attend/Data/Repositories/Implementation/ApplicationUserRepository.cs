using E_Attend.Data.Context;
using E_Attend.Data.Repositories.Interface;
using E_Attend.Entities;

namespace E_Attend.Data.Repositories.Implementation;

public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
{
    private readonly ApplicationDbContext context;
    public ApplicationUserRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }
}