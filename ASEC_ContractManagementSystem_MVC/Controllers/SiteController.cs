using ASEC_ContractManagementSystem_API.Common.Paging;
using ASEC_ContractManagementSystem_MVC.Common.Paging;
using ASEC_ContractManagementSystem_MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ASEC_ContractManagementSystem_MVC.Controllers
{
    public class SiteController : Controller
    {
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
                return RedirectToAction("Login", "Login");
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _client.GetAsync("api/Site");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ExtendedPaging<SiteInstruction>>(data);
                model.ListData = result?.ListData;
                model.Projects = result?.Projects;

                return View(model);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
            {
                HttpContext.Session.Remove("JwtToken");
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetData(int page,int pageSize, string? keyWord)
        {
            var model = new PaginatedResult<SiteInstruction>();
            string token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Login");
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _client.GetAsync($"api/Site/GetSiteData?p={page}&ItemsPerPage={pageSize}&s={keyWord}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PaginatedResult<SiteInstruction>>(data);
                model.data = result?.data;
                model.pageCurrent = result.pageCurrent;
                model.numSize = result.numSize;
                model.Keyword = result.Keyword;
                return Json(model);
            }
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest)
            {
                HttpContext.Session.Remove("JwtToken");
                return RedirectToAction("Login", "Login");
            }
            return View(model);
        }
    }
}
