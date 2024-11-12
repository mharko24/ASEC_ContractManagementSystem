using ASEC_ContractManagementSystem_MVC.Common.Paging;
using ASEC_ContractManagementSystem_MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace ASEC_ContractManagementSystem_MVC.Controllers
{
    public class SiteController : Controller
    {
        //Uri baseAddress = new Uri("http://localhost:5240/api");
        Uri baseAddress = new Uri("http://localhost:5240");
        private readonly HttpClient _client;
        public SiteController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new ExtendedPaging<SiteInstruction>();

            string token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }
            //_client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
           // _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           //HttpResponseMessage response = await _client.GetAsync("/Site");
            HttpResponseMessage response = await _client.GetAsync("api/Site");
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                model.ListData = JsonConvert.DeserializeObject<List<SiteInstruction>>(data);
                return View(model);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
            {
                HttpContext.Session.Remove("JwtToken");
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

    }
}
