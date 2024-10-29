using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.AutoMapper
{
    public class UrunProjeMapper:Profile
    {
        public UrunProjeMapper()
        {
           
            CreateMap<Urun,UrunEkleDTO>().ReverseMap();
            CreateMap<Urun, UrunGuncelleDTO>().ReverseMap();
            CreateMap<Urun,UrunDetay_VM >().ReverseMap();
            CreateMap<YeniUyeDTO,YeniUyeEkleVM>().ReverseMap();

          
            //CreateMap< List<Urun>, List<UrunVM>>().ReverseMap();
            CreateMap<Urun,UrunVM>().ReverseMap();
            //Kategori
            CreateMap<Kategorı, KategoriDTO>().ReverseMap();
            CreateMap<Kategorı,KategoriVM>().ReverseMap();
            CreateMap<Kategorı,KategoriEkleDTO>().ReverseMap();
            CreateMap<Kategorı,KategoriGuncelleDTO>().ReverseMap();

            //Sepet

            CreateMap<Sepet, SepeteUrunEkleDTO>().ReverseMap();
            CreateMap<Sepet, SepettekiUrunAdetGuncelleDTO>().ReverseMap();
            CreateMap<Sepet, SepetVM>().ForMember(x=>x.UrunAdi,y=>y.MapFrom(y=>y.Urun.UrunAdi)).ReverseMap(); 




        }
    }
}
