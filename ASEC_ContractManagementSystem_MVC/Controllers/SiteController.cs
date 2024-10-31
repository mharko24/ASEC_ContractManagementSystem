using ASEC_ContractManagementSystem_MVC.Common.Paging;
using ASEC_ContractManagementSystem_MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ASEC_ContractManagementSystem_MVC.Controllers
{
    public class SiteController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5240/api");
        private readonly HttpClient _client;
        public SiteController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new ExtendedPaging<SiteInstruction>();
            HttpResponseMessage response =  _client.GetAsync(_client.BaseAddress + "/site").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model.ListData = JsonConvert.DeserializeObject<List<SiteInstruction>>(data);
                
                return View(model);
            }
            return View();
        }
    }
}
