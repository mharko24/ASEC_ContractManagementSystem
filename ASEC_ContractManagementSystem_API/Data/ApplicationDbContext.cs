using ASEC_ContractManagementSystem_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASEC_ContractManagementSystem_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<SiteInstruction> SiteInstructions { get; set; }
        public virtual DbSet<PotentialClaim>PotentialClaims{ get; set; }
        public virtual DbSet<FileUpload> FileUploads { get; set; }
    }
}
