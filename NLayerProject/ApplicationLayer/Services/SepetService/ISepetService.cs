using ApplicationLayer.Models.DTO_s;
using ApplicationLayer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.SepetService
{
    public interface ISepetService
    {
        Task SepeteUrunEkleAsync(SepeteUrunEkleDTO sepeteUrunEkleDTO);
        Task SepettenUrunCıkarAsync(int id);//SepetID

       IEnumerable<SepetVM>SepettekiTumUrünler();

        Task SepettekiUrunAdediniGuncelleAsync(SepettekiUrunAdetGuncelleDTO sepettekiUrunAdetGuncelle );
    }
}
