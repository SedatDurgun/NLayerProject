using DomainLayer.Repositories.Abstract;
using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using Infrastructurel.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UrunService
{
    public class UrunService : IUrunService
    {
        private readonly IUrunRepository _repository;
        private readonly IMapper _mapper;
        public UrunService(IUrunRepository urunRepostory,IMapper mapper)
        {
            _repository = urunRepostory; 
            _mapper = mapper;
        }

        public async Task<UrunGuncelleDTO> GuncelUrunAsync(int id)
        {
            Urun urun = await _repository.AraAsync(id);
            UrunGuncelleDTO guncelleDTO= new UrunGuncelleDTO(); 
            _mapper.Map(urun, guncelleDTO);
            return guncelleDTO;
        }

        public async Task<IEnumerable<UrunVM>> HangiKategoriAsync(int KategriID)
        {
           List<Urun> urunler=  _repository.TumAktifleriListeleAsync().Result.Where(x=>x.KategoriID== KategriID).ToList();
            List<UrunVM> urunlerVM= new List<UrunVM>();
            _mapper.Map(urunler,urunlerVM);

            return urunlerVM;
        }

        public async Task<IEnumerable<UrunVM>> TumUrunlerAsync()
        {
            List<Urun> urunler=  _repository.TumAktifleriListeleAsync().Result.ToList();
            List<UrunVM> urunlerVm= new List<UrunVM>();
            _mapper.Map(urunler,urunlerVm);
            return urunlerVm;
        }

        public async Task<UrunDetay_VM> UrunBulAsync(int id)
        {
            Urun urun = await _repository.AraAsync(id);
            
            UrunDetay_VM urunDetay=new UrunDetay_VM();
            _mapper.Map(urun,urunDetay);
            return urunDetay;
        }

        public async Task UrunEkleAsync(UrunEkleDTO urunEkleDTO)
        { //???
            // Her seferişnde böyle kullanacka mıyız
            //AutoMapper Kullanacağız
            Urun urun = new Urun();
            /*IMapper kullandığınmız için buraye gerke kalmamşıştır*/
            //urun.UrunAdi=urunEkleDTO.UrunAdi;
            //urun.Resim=urunEkleDTO.Resim;
            //urun.Fiyat=urunEkleDTO.Fiyat;
            //urun.Acıklama=urunEkleDTO.Acıklama;
            //urun.UrunVideo=urunEkleDTO.UrunVideo;
            //urun.KategoriID=urunEkleDTO.KategoriID;

            _mapper.Map(urunEkleDTO, urun);
            await _repository.EkleAsync(urun);
        }

        public async Task<bool> UrunGuncelleAsync(UrunGuncelleDTO urunGuncelleDTO)
        {
            Urun urun   =new Urun();
            _mapper.Map(urunGuncelleDTO, urun);

           return await _repository.GüncelleAsync(urun);
        }

        public async Task<bool> UrunSilAsync(int id)
        {
            return await _repository.SilAsync(id);
        }
    }
}
