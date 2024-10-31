using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_MVC.Entities
{
    public class SiteInstruction
    {
        [Key]
        public int CMSiteId { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Project Name")]
        public string? ProjectName { get; set; }
        [Required]
        [Display(Name = "CM-PMI Number")]
        public string? CMPMINumber { get; set; }
        [Required]
        [Display(Name = "Asec-PMI Number")]
        public string? AsecPMINumber { get; set; }
        [Required]
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }
        public string Status { get; set; } = "Open";
        public decimal? Amount { get; set; }
        public int? Completion { get; set; }
        public decimal? EquivAmount { get; set; }
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
