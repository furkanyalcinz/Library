using Client.Helper;
using Client.Models;
using Client.Schemas;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

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
            
            client.DefaultRequestHeaders.Add("Authorization", "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InN0cmluZyBzdHJpbmciLCJlbWFpbCI6InN0cmluZ0B0ZXN0LmNvbSIsInJvbGUiOiJBZG1pbiIsIm5iZiI6MTY4ODA1NzM0NSwiZXhwIjoxNjg4MDYwOTQ1LCJpYXQiOjE2ODgwNTczNDUsImlzcyI6IkxpYnJhcnlBcHAuY29tIn0.tT0RTqQ-XWFK5DoPCgCsLPR9NHDHmi-qFlpVwVE3rFI");
            HttpResponseMessage response = await client.GetAsync("api/Book/GetAllBooks");
            
            var result =  response.Content.ReadAsStringAsync().Result;
            var res = JsonConvert.DeserializeObject<Result<Book>>(result);
            var data = res.Data;
            
            ViewBag.client = client;
            return View(data);
            
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