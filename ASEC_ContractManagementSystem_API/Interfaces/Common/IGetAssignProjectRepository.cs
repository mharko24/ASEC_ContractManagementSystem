using ASEC_ContractManagementSystem_API.Models.ViewModels.ProjectDetails;

namespace ASEC_ContractManagementSystem_API.Interfaces.Common
{
    public interface IGetAssignProjectRepository
    {
        Task<List<ProjectDetailsVM?>> AssignProjects(int userId);
    }
}
