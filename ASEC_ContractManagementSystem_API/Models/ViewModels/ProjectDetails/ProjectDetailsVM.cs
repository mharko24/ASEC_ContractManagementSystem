namespace ASEC_ContractManagementSystem_API.Models.ViewModels.ProjectDetails
{
    public class ProjectDetailsVM
    {
        public string ProjName { get; set; }
        public string ProjCode { get; set; }
        public int isUnique { get; set; }
        public string PONumber { get; set; }
        public decimal? ProjectCompletion { get; set; }
    }
}
