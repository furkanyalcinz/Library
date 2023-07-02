
using Client.Helper;
using Client.Models;
using Client.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Web;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           
            var client = new ApiHelper().Client();
            
            client.DefaultRequestHeaders.Add("Authorization", "bearer ");
            HttpResponseMessage response = await client.GetAsync("api/Book/GetAllBooks");
            
            var result =  response.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<Result<Book>>(result);
            var data = res.Data;   
            
            ViewBag.client = client;
            return View(data);
            
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string name, string surname, string email, string password)
        {
            var client = new ApiHelper().Client();
            var requestData = new
            {
                name = name,
                surname = surname,
                email = email,
                password = password
            };

            string jsonPayload = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/User/Register",content);   
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result>(responseContent);
            ViewBag.Result = result;
            return Ok(result);
            
        }
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("Email") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var requestData = new
            {
                email = email,
                password = password
            };
            string jsonPayload = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var client = new ApiHelper().Client();
            HttpResponseMessage response = await client.PostAsync("api/User/Login", content);
            var result = response.Content.ReadAsStringAsync().Result;
            
            var res = JsonConvert.DeserializeObject<Result<LoginResult>>(result);
            if(res.Success == true)
            {
                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("Token", res.Data[0].Token);

                return Ok(res);
            }
            else
            {
                ViewBag.Success = res.Success;

                return Ok(res);
            }
 
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(string bookId, DateOnly date)
        {
            
            var client = new ApiHelper().Client();
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return BadRequest("You should login first");
            }
            if (date.ToString() == "01/01/0001")
            {
                return BadRequest("You should select a date");
            }
            if (date == null)
            {
                return BadRequest("Add return date");
            }
     
            
            if(token == null)
            {
                return RedirectToAction("Login");
            }
            client.DefaultRequestHeaders.Add("Authorization", "bearer "+token);
            string url = "api/Book/Reserve?BookId=" + bookId;
            string jsonPayload = JsonConvert.SerializeObject(date);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}