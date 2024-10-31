using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class PotentialClaim
    {
        [Key]
        public int PotId { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Project Name")]
        public string? ProjectName { get; set; }
        [Required]
        [Display(Name = "CVI Number")]
        public string CVINumber { get; set; }
        [Required]
        [Display(Name = "Asec-PMI Number")]
        public string AsecPMINumber { get; set; }
        public string Remarks { get; set; }

        public string Status { get; set; } = "Open";

        public decimal? Amount { get; set; }
        public int? Completion { get; set; }
        public int? EquivAmount { get; set; }
        public string? PONumber { get; set; }

        public int? Additive { get; set; }
        public int? Deductive { get; set; }
        public int? BilledCompletion { get; set; }
        public int? EquivBilled { get; set; }
        public DateTime? ModifyDate { get; set; }
        [StringLength(20)]
        public string? ProjCode { get; set; }
        public int? UserId { get; set; }
    }
}
