using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using ApplicationLayer.Services.KategoriService;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UILayer.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")]
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;
        private readonly IMapper _mapper;

        public KategoriController(IKategoriService kategoriService, IMapper mapper)
        {
            _kategoriService = kategoriService;
            _mapper = mapper;
        }
       

        public async Task <IActionResult> Index()
        {
            var kategoriler= await _kategoriService.TümKategorilerAsync();

           
            return View(kategoriler);
        }

        [HttpGet]
        public async Task <IActionResult> KategoriEkle() 
        {
          ViewBag.Kategoriler= new SelectList(await _kategoriService.TümKategorilerAsync(),"KategoriID","KategoriAdi");
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle(KategoriVM kategori)
        {
           if (ModelState.IsValid)
            {
                KategoriEkleDTO kategoriEkleDTO = new KategoriEkleDTO();
                kategoriEkleDTO.KategoriAdi = kategori.KategoriAdi;

                Guid guid = Guid.NewGuid();

                if(kategori.KategoriAdi != null)
                {
                    string kategoriAdi= guid.ToString()+kategori.KategoriAdi;
                }
                else
                {
                    kategoriEkleDTO.KategoriAdi = "Kategori Adı Giriniz";
                }
                await _kategoriService.KategoriEkleAsync(kategoriEkleDTO);
                return RedirectToAction("Index");
            }

           
            ViewBag.Kategoriler = new SelectList(await _kategoriService.TümKategorilerAsync(), "KategoriID", "KategoriAdi");
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> KategoriGuncelle(int id)
        {
            //var katID=  await _kategoriService.KategoriGüncelleAsync(id);

            var getKat = await _kategoriService.KategoriBulAsync(id);
           // Console.WriteLine(getKat.KategoriID+"...");
          getKat.KategoriID = id;
            return View(getKat);

            
        }

        [HttpPost] 
        public async Task <IActionResult> KategoriGuncelle(KategoriVM kategori)
        {
            if (ModelState.IsValid)
            {
               
               KategoriGuncelleDTO kategoriDTO = new KategoriGuncelleDTO();
                kategoriDTO.KategoriID= (int) kategori.KategoriID;
                    kategoriDTO.KategoriAdi= kategori.KategoriAdi;

                    await _kategoriService.KategoriGüncelleAsync(kategoriDTO);

                return RedirectToAction("Index");
            }

              return View();
        }
    }
}
