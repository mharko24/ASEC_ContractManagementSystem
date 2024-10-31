using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class FileUpload
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; }
        [NotMapped]
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public byte[] FileContent { get; set; }
        public int? UserId { get; set; }
        public long Size { get; set; }
        [ForeignKey("SiteInstruction")]
        [Column("CMSiteId")]
        public int? CMSiteId { get; set; }
        public SiteInstruction? SiteInstruction { get; set; }
        [ForeignKey("PotentialClaim")]
        [Column("PotId")]
        public int? PotId { get; set; }
        public PotentialClaim? PotentialClaim { get; set; }

        //[ForeignKey("EOTId")]
        public int? EOTId { get; set; }
        //[ForeignKey("EOTId")]
        //[NotMapped]
        //public EOTClaim? EOTClaim { get; set; }

        //[ForeignKey("BillingId")]
        public int? BillingId { get; set; }
        //[NotMapped]
        //public Billing? Billings { get; set; }

        public int? SubconId { get; set; }

        //[NotMapped]
        //[ForeignKey("Id")]
       // public Subcon? Subcon { get; set; }
    }
}
