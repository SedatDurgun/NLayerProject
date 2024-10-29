using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace ApplicationLayer.Services.SepetService
{
    public class SepetService : ISepetService
    {
        private readonly ISepetRepostory _sepetRepostory;
        private readonly IMapper _mapper;

        public SepetService(ISepetRepostory sepetRepostory, IMapper mapper)
        {
            _sepetRepostory = sepetRepostory;
            _mapper = mapper;
        }

        public async Task SepeteUrunEkleAsync(SepeteUrunEkleDTO sepeteUrunEkleDTO)
        {
            //?? Sepette o uyeye ait ilgili urunden yokdssa INSERT et..
            //varsa urun adedini artır..UPDATE


         var tumAktifListe= await   _sepetRepostory.TumAktifleriListeleAsync();

            bool varMi= tumAktifListe.Where(x=>x.UrunID== sepeteUrunEkleDTO.UrunID && x.UyeID==sepeteUrunEkleDTO.UyeID).Any(); //Bu kod ile kullanıcı sepete her ekleme yaptığında INSERT(tabloya veya sütuna birden fazla satır eklemek) etmek yerine sepeteki ürün adetini artıracaz
            Sepet sepet = new Sepet();
            _mapper.Map(sepeteUrunEkleDTO, sepet);

            if (varMi) // varsa bir adet artır
            {
                sepet.Adet += 1;
                await _sepetRepostory.GüncelleAsync(sepet);
            }
            else 
            {
                await _sepetRepostory.EkleAsync(sepet);
            }

            await _sepetRepostory.EkleAsync(sepet);
       }

       
        public IEnumerable<SepetVM> SepettekiTumUrünler()
        {
           var liste = _sepetRepostory.TumAktifleriListeleInclude().Include(x=>x.Urun).ToList();
            List<SepetVM> sepetVM= new List<SepetVM>();
            _mapper.Map(liste, sepetVM);
            return sepetVM;
        }

        public async Task SepettekiUrunAdediniGuncelleAsync(SepettekiUrunAdetGuncelleDTO sepettekiUrunAdetGuncelle)
        {
            Sepet sepet = new Sepet();
            _mapper.Map(sepettekiUrunAdetGuncelle, sepet);
            await _sepetRepostory.GüncelleAsync(sepet);
        }

        public async Task SepettenUrunCıkarAsync(int id)
        {
           await _sepetRepostory.SilAsync(id);
        }
    }
}