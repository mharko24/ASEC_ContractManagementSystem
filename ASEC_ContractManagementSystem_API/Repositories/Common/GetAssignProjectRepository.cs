using ASEC_ContractManagementSystem_API.Data;
using ASEC_ContractManagementSystem_API.Interfaces.Common;
using ASEC_ContractManagementSystem_API.Models.ViewModels.ProjectDetails;
using Microsoft.EntityFrameworkCore;

namespace ASEC_ContractManagementSystem_API.Repositories.Common
{
    public class GetAssignProjectRepository : IGetAssignProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public GetAssignProjectRepository(
            ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<ProjectDetailsVM?>> AssignProjects(int userId)
        {
            var assignProjects = await _db.UserProjects
                    .Where(x => x.UserId == userId)
                    .Join(_db.ProjectDetails,
                    User => User.ProdId,
                    project => project.Id,
                    (User, project) => project)
                    .Select(x => new ProjectDetailsVM
                    {
                        ProjCode = x.ProjectCode,
                        ProjName = x.ProjectName,
                        isUnique = x.isUnique,
                        PONumber = x.PONumber ?? string.Empty,
                        ProjectCompletion = x.ProjectCompletion
                    })
                    .ToListAsync();
            if (assignProjects == null || assignProjects.Count == 0)
            {
                assignProjects = await _db.ProjectDetails
                    .Select(x => new ProjectDetailsVM
                    {
                        ProjCode = x.ProjectCode,
                        ProjName = x.ProjectName,
                        isUnique = x.isUnique,
                        PONumber = x.PONumber ?? string.Empty,
                        ProjectCompletion = x.ProjectCompletion
                    })
                     .ToListAsync();
            }

            return assignProjects;
        }
    }
}
