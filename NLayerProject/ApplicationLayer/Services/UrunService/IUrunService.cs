using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.UrunService
{
    public interface IUrunService
    {
        Task<UrunDetay_VM> UrunBulAsync(int id);

        Task<UrunGuncelleDTO> GuncelUrunAsync(int id);                             
        Task UrunEkleAsync(UrunEkleDTO urunEkleDTO);

        Task<bool> UrunGuncelleAsync(UrunGuncelleDTO urunGuncelleDTO);

        Task<bool> UrunSilAsync(int id); // Silme işlemi id ile yapacağım için sadece id ile yakalıyorum

        Task<IEnumerable<UrunVM>> TumUrunlerAsync();

        Task<IEnumerable<UrunVM>> HangiKategoriAsync(int KategriID);
    }
}
