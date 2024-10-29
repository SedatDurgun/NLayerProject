using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.ViewModels
{
    public class UrunDetay_VM
    {
        public int UrunID { get; set; }

        public string UrunAdi { get; set; }

        public string Acıklama { get; set; }

        public decimal Fiyat { get; set; }

        public string Resim { get; set; }

        public string UrunVideo { get; set; }
        public string KategoriAdi { get; set; }

    }
}
