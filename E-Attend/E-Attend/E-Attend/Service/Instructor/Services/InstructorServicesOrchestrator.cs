using E_Attend.Entities.Repositories;

namespace E_Attend.Service.Assignment;

public class InstructorServicesOrchestrator : IInstructorServicesOrchestrator {
    public AssignmentService AssignmentService { get; }
    private readonly IUnitOfWork unitOfWork;

    public InstructorServicesOrchestrator(IUnitOfWork unitOfWork) {
        this.unitOfWork = unitOfWork;
        this.AssignmentService = new AssignmentService(unitOfWork);
    }
    
    
    
}