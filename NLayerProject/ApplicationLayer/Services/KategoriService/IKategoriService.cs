



using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.KategoriService
{
    public interface IKategoriService
    {
        Task<KategoriVM> KategoriBulAsync(int id ); // int id ile ürüne ait Kategoriyi id ile bulabilir miyim.
        
        Task KategoriEkleAsync(KategoriEkleDTO kategoriEkleDTO);
        Task <bool>  KategoriGüncelleAsync(KategoriGuncelleDTO kategoriGuncelleDTO);
        Task<bool> KategoriSil(int id); // Silme 
        Task<IEnumerable<KategoriVM>> KategoriListeleAsync();
        Task<List<KategoriDTO>> TümKategorilerAsync();
        Task<KategoriGuncelleDTO> KategoriGüncelleAsync(int id);
    }
    //Soru-  Kategorileri DTO üzerinden değilde VM model üzerinden yakalarsak herhangi bir fark olur mu.
}
