using ASEC_ContractManagementSystem_API.Entities;
using ASEC_ContractManagementSystem_API.Models.ViewModels.ProjectDetails;

namespace ASEC_ContractManagementSystem_API.Common.Paging
{
    public class ExtentedPagination<T> where T : class
    {
        public IEnumerable<T>? ListData { get; set; }
        public List<ProjectDetailsVM>? Projects { get; set; }
    }
}
