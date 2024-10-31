using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class Subcon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SubconId { get; set; }
        [Required]
        public string? SubconName { get; set; }
        [Required]
        public string? Project { get; set; }
        [Required]
        public string? ProjectCode { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [Required]
        public string? SCCNumber { get; set; }
        [Required]
        public int DPAmount { get; set; }
        [Required]
        public string? PaymentTerms { get; set; }
        [Required]
        public string? BillingNumber { get; set; }
        [Required]
        public string? ProjectLocation { get; set; }

        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        
        public DateTime ToDate { get; set; }
        //public string? PeriodCovered => $"{FromDate:MMMM dd}-{ToDate:MMMM dd,yyyy}";
        [Required]
        public string? Status { get; set; }
        [Required]
        public int SubTotal { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int DPRecoupment { get; set; }
        [Required]
        public int Retention { get; set; }
        [Required]
        public int EWT { get; set; }
        public int Others { get; set; }
        


    }
}
