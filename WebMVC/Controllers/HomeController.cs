using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IExampleService _exampleService;

        public HomeController(ILogger<HomeController> logger, IExampleService exampleService)
        {
            _logger = logger;
            _exampleService = exampleService;
        }

        public async Task<IActionResult> Index()
        {
            var result= await _exampleService.GetAllAsync();
            if (result.Success)
            {
                return View(result.Data);
            }
            return View();
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