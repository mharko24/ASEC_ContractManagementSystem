using System.ComponentModel.DataAnnotations.Schema;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class UserProject
    {
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }
        public UserApp? UserApps { get; set; }
        [ForeignKey("ProdId")]
        public int? ProdId { get; set; }

        public string ProjCode { get; set; }
       
    }
}
