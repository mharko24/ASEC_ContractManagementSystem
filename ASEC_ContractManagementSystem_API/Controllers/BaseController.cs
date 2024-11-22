using Microsoft.AspNetCore.Mvc;

namespace ASEC_ContractManagementSystem_API.Controllers
{
    public class BaseController : ControllerBase
    {
        public int UserId
        {
            get
            {
                return User.Claims.Where(x => x.Type == "sid").Select(x => int.TryParse(x.Value, out int userid) ? userid : 0).FirstOrDefault();
            }
        }
    }
}
