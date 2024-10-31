using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class EOTClaim
    {
        [Key]
        public int EOTId { get; set; }
        [Required(ErrorMessage = "Date field is Required!")]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Required]
        [Display(Name = "PMI Number")]
        public string PMINumber { get; set; }
        [Required]
        [Display(Name = "VO Number")]
        public string VONumber { get; set; }
        public string Remarks { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; } = "Open";
        [Required]
        [Display(Name = "PO Number")]
        public string PONumber { get; set; }
        public DateTime? ModifyDate { get; set; }
        [StringLength(20)]
        public string? ProjCode { get; set; }
    }
}
