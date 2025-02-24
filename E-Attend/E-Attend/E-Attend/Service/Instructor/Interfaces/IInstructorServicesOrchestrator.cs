using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Assignment;

public interface IInstructorServicesOrchestrator {
   public  AssignmentService  AssignmentService { get; }
}