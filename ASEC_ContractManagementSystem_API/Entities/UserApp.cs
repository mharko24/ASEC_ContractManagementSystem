using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class UserApp
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
    }
}
