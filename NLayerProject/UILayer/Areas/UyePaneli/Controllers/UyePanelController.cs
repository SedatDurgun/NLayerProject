
using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Services.SepetService;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace UILayer.Areas.UyePaneli.Controllers
{
    [Area("UyePanel")]
    public class UyePanelController : Controller
    {
        private readonly ISepetService _sepetService;
        private readonly UserManager<Uye> _userManager; // Uye ID burdan almak için kullanıyoruz 
        private readonly IMapper _mapper;

        public UyePanelController(ISepetService sepetService, UserManager<Uye> userManager, IMapper mapper)
        {
            _sepetService = sepetService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var sepettekiUrunler = _sepetService.SepettekiTumUrünler();
            return View(sepettekiUrunler);
        }

        [HttpPost] // Var olan dataları eklediğimiz için get kullanmıyoruz
        public async Task <IActionResult> SepetEkle(int id) //Urun ID
        {
            SepeteUrunEkleDTO ekleDTO = new SepeteUrunEkleDTO();
            ekleDTO.UrunID = id;
            ekleDTO.Adet = 1;
            ekleDTO.UyeID = GetUserID(); // uye ıd bu metod ile çağırdık

            await _sepetService.SepeteUrunEkleAsync(ekleDTO);

            return Redirect("~/Home/Index"); // Bu Kod ile sepete ekleme yapıtığında aynı sayfa da kalmasını sağlıyor 
        }

        public int GetUserID()
        {
           return int.Parse( _userManager.GetUserId(User));
        }
    }
}
