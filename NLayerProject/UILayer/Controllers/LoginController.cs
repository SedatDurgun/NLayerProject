using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using ApplicationLayer.Services.UserService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class LoginController : Controller // Generate ctor yap
    {
       private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LoginController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Login(LoginDTO loginDTO) // Data eklemeyi unutma 
        {
          //  await Console.Out.WriteLineAsync(loginDTO.Eposta+ " "+ loginDTO.Sifre); //Console üzerinden bilgilerin doğru gelip gelmdeğini kontrol ediyoruz.
            var result = await _userService.LoginAsync(loginDTO);

            //await Console.Out.WriteLineAsync($"\n\n>>>UyeVarmi={result.UyeVarmi} YoneticiMi={result.YoneticiMi} NormalUyeMi={result.UyeMi}");  //Sunucu tarafında ekrana yazıyor ordan resulr kısmını doğru olup olmadığını kontrol ediyoruz

           

            
            if (result.UyeVarmi)
            {
               // return Content("Uyeniz bulunmaktadır");
               //return new EmptyResult();
               return RedirectToAction("Index", "Home");
            }
            //else içerisinde de kullanabilirsin ancak if içerisinde if kullandığımız için else yazmaya gerek yok 
            ModelState.AddModelError("Hata", "Kullanıcı adı veya Şifre yanlış");
            return View();


            return View();
        }

        [HttpGet]
        public IActionResult YeniUyeEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> YeniUyeEkle(YeniUyeEkleVM uye)
        {
            if (ModelState.IsValid)
            {
                YeniUyeDTO yeniUyeDTO = new YeniUyeDTO();
                _mapper.Map(uye, yeniUyeDTO);

             await  _userService.YeniUyeEkleAsync(yeniUyeDTO);
                return RedirectToAction("Login"); // İlerde 
            }
            else 
            { return View(); }
        }
        public async Task <IActionResult> Logout()
        {
            await _userService.LogOutAsync();
            //return new EmptyResult();// Logout işleminden dolayı boş sayfa dönüyor.
            return RedirectToAction("Index", "Home");
        }
    }
}
