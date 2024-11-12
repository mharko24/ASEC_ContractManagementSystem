using ASEC_ContractManagementSystem_API.Entities;
using ASEC_ContractManagementSystem_API.Models.ViewModels;
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
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<UserApp> UserApps { get; set; }
        //public virtual DbSet<UserModel> UserModel { get; set; }
    }
}
