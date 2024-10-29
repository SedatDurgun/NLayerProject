using Microsoft.AspNetCore.Mvc;

namespace UILayer.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")] 
    public class AdminPanel : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
