using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class ProjectDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string ProjectCode { get; set; }
        [Required]
        public string ProjectName { get; set; }
        public int? OrigContractAmount { get; set; }
        [Required]
        public string Address { get; set; }
        [StringLength(10)]
        public string? PONumber { get; set; }
        public decimal? ProjectCompletion { get; set; }
        public int Active { get; set; }
        public int isUnique { get; set; }
    }
}
