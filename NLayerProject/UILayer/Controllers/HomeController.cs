using ApplicationLayer.Services.UrunService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UILayer.Models;

namespace UILayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrunService _urunService;
      

        public HomeController(ILogger<HomeController> logger, IUrunService urunService) 
        {
            _logger = logger;
            _urunService = urunService;
        }

        public async Task <IActionResult> Index()
        {
            var urunler = await _urunService.TumUrunlerAsync();
            return View(urunler);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var urun = await _urunService.UrunBulAsync(id);
            return View(urun);
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
