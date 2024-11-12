using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ASEC_ContractManagementSystem_API.Entities
{
    public class AppUser:IdentityUser
    {
        [MaxLength(100)]
        [StringLength(100)]
        [Required]
        public string? Name { get; set; }
        [MaxLength(100)]
        [StringLength(100)]
        [Required]
        public string? Department { get; set; }
        public string? AssignProject { get; set; }
    }
}
