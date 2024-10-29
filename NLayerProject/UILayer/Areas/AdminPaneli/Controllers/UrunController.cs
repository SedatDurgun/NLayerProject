using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Services.KategoriService;
using ApplicationLayer.Services.UrunService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UILayer.Models;

namespace UILayer.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")] // Hangi panele ait olduğunu bekliyoruz
    public class UrunController : Controller // Generate ctor yapıldı
    {
        //Servisler Eklenecek
        private readonly IUrunService _urunService;
        private readonly IKategoriService _kategoriService;
        private readonly IMapper _mapper;

        public UrunController(IUrunService urunService, IKategoriService kategoriService, IMapper mapper)
        {
            _urunService = urunService;
            _kategoriService = kategoriService;
            _mapper = mapper;
        }

        public async Task< IActionResult> Index()
        {
           var urunler= await _urunService.TumUrunlerAsync(); 
            return View(urunler);
        }

        [HttpGet]
        public async Task<IActionResult> UrunEkle()
        {
            ViewBag.Kategoriler = new SelectList( await _kategoriService.TümKategorilerAsync(), "KategorıID", "KategoriAdi"); 

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UrunEkle(UrunEkleVM urun)
        {

            if (ModelState.IsValid) 
            {
                

                UrunEkleDTO urunEkleDTO = new UrunEkleDTO();
                //   _mapper.Map(urun, urunEkleDTO); Alt katmandan bunu tanımlayadığımız için mapper kullanamayız 

                //DBCC CHECKIDENT(Urunler, RESEED, 0)

                urunEkleDTO.UrunAdi = urun.UrunAdi;
                urunEkleDTO.Acıklama= urun.Acıklama;
                urunEkleDTO.Fiyat= urun.Fiyat;
                urunEkleDTO.KategoriID = urun.KategoriID;   


               
                Guid guid = Guid.NewGuid(); 
                if (urun.Resim != null) {

                    string resimAdi = guid.ToString() + urun.Resim.FileName;
                    FileStream fsResim= new FileStream("wwwroot/UrunResimleri/"+ resimAdi,FileMode.CreateNew); 
                    await  urun.Resim.CopyToAsync(fsResim);
                    urunEkleDTO.Resim = resimAdi;
                    fsResim.Close();

                }
                else
                {
                    urunEkleDTO.Resim = "bosResim.jpg";
                }

                if (urun.UrunVideo!=null)
                {
                    string videoAdi = guid.ToString() + urun.UrunVideo.FileName;
                    FileStream fsVideo = new FileStream("wwwroot/UrunVideolari/" +videoAdi, FileMode.CreateNew);
                    await urun.UrunVideo.CopyToAsync(fsVideo);
                    urunEkleDTO.UrunVideo = videoAdi;
                    fsVideo.Close();
                }
                else
                {
                    urunEkleDTO.UrunVideo = "VideoYok";

                }
                await  _urunService.UrunEkleAsync(urunEkleDTO);
                return RedirectToAction("Index");

            }

            ViewBag.Kategoriler = new SelectList(await _kategoriService.TümKategorilerAsync(), "KategorıID", "KategoriAdi");

            return View();
        }

        [HttpGet]
        public async Task <IActionResult> UrunGuncelle(int id)
        {
            
            var urun= await  _urunService.GuncelUrunAsync(id);

            var kategoriler = await _kategoriService.TümKategorilerAsync();
           // int katID = kategoriler.Find(x => x.KategoriAdi == urun.KategoriAdi).KategorıID;
            ViewBag.Kategoriler = new SelectList(kategoriler, "KategorıID", "KategoriAdi",urun.KategoriID);

            return View(urun);  
        }


        public async  Task <IActionResult> UrunGuncelle(UrunGuncelleDTO urun)
        {
            if(ModelState.IsValid)
            {
                

                await _urunService.UrunGuncelleAsync(urun);
                return RedirectToAction("Index");

            }
            ViewBag.Kategoriler = new SelectList(await _kategoriService.TümKategorilerAsync(), "KategorıID", "KategoriAdi");
            return View();
        }

        [HttpPost]

        public  async Task<IActionResult> UrunSil(int id)
        {
            await _urunService.UrunSilAsync(id);
            return RedirectToAction("Index");
        }
    }
}
