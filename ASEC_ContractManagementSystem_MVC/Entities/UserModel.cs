namespace ASEC_ContractManagementSystem_MVC.Entities
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public DateTime DateOfEntry { get; set; } = DateTime.Now;
    }
}
