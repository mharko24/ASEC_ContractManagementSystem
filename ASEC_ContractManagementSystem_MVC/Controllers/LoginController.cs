using ASEC_ContractManagementSystem_MVC.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ASEC_ContractManagementSystem_MVC.Controllers
{
    public class LoginController : Controller
    {

        Uri baseAddress = new Uri("http://localhost:5240/api");
        private readonly HttpClient _client;
        public LoginController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Login",model);
            }

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync(_client.BaseAddress + "/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    {
                        token = token.Substring("Bearer ".Length);
                    }
                    HttpContext.Session.SetString("JwtToken", token);
                    return RedirectToAction("Index", "Site");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("Login", model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while processing your login.");
                return View("Login", model);
            }
            
        }
        public async Task<IActionResult> SignOut()
        {
            var response = await _client.GetAsync(_client.BaseAddress + "/Logout");
            return RedirectToAction("Login");
        }
    }
}
