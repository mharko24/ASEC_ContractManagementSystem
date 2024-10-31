using System.ComponentModel.DataAnnotations.Schema;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class UserProject
    {
        public int Id { get; set; }

        [ForeignKey("Id")]
        public string AppUserId { get; set; }
        public AppUser? AppUsers { get; set; }

        public string ProjCode { get; set; }
       
    }
}
