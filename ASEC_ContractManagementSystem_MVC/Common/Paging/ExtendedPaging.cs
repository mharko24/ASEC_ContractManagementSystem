using ASEC_ContractManagementSystem_API.Entities;
using ASEC_ContractManagementSystem_MVC.Models.ViewModels.ProjectDetails;

namespace ASEC_ContractManagementSystem_MVC.Common.Paging
{
    public class ExtendedPaging<T> where T : class
    {
        public IEnumerable<T>? ListData { get; set; }
        public List<ProjectDetailsVM>? Projects { get; set; }

    }
}
