using ApplicationLayer.Models.DTO_s;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<Uye> _userManager;
        private readonly SignInManager<Uye> _signInManager;

        //CTOR Injection
        public UserService(UserManager<Uye> userManger, SignInManager<Uye> signInManager)
        {
            _userManager = userManger;
            _signInManager = signInManager;
        }


       
        public async Task<LoginResultDTO> LoginAsync(LoginDTO login)
        {
            LoginResultDTO resultDTO= new LoginResultDTO()
            {
                YoneticiMi=false,
                UyeMi=false,
                UyeVarmi=false,
            };

           Uye? uye = await _userManager.FindByEmailAsync(login.Eposta);

            if (uye == null) //Uye yoksa null dönecek
            { 
                return resultDTO;
            }
           
            if (await _userManager.CheckPasswordAsync(uye, login.Sifre))
            {
                //Şifre Doğru ise 
                resultDTO.UyeVarmi= true;
                resultDTO.UyeMi=true;

                //Uye Yönereici ise 
                resultDTO.YoneticiMi = await _userManager.IsInRoleAsync(uye, "Yonetici");

                //Uyeyi sisteme SignIn yap...
                await _signInManager.SignInAsync(uye, true);
            } ;

            return resultDTO;
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async  Task<bool> YeniUyeEkleAsync(YeniUyeDTO yeniUye)
        {
            // Daha Sonra kolay bir yöntem gösterilecek
            //Gelen nesne ile CreateAsync() metodunun beklendiği tip birbirinden farklı...

            Uye uye= new Uye();
            uye.Ad= yeniUye.Ad;
            uye.Soyad= yeniUye.Soyad;
            uye.Adres= yeniUye.Adres;
            uye.UserName = yeniUye.KullanıcıAdı;
            uye.Email = yeniUye.Eposta;
            
            //Gelen sdifre verisine hashlenmesi için yazdık...
            PasswordHasher<Uye> passwordHasher = new PasswordHasher<Uye>();
            uye.PasswordHash=passwordHasher.HashPassword(uye,yeniUye.Sifre);

            uye.SecurityStamp= Guid.NewGuid().ToString();
            uye.ConcurrencyStamp= Guid.NewGuid().ToString();


            //Sisteme üye olan her yani kullanıcı uye rolu ile olusturulur...
            var result = await _userManager.CreateAsync(uye);
           
            await _userManager.CreateAsync(uye);

            
            return result.Succeeded;
        }
    }
}
