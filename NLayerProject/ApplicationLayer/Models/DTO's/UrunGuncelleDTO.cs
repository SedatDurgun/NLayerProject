using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTO_s
{
   public class UrunGuncelleDTO
    {
        public int UrunID { get; set; }

        public string UrunAdi { get; set; }

        public string Acıklama { get; set; }

        public decimal Fiyat { get; set; }

        public string Resim { get; set; }

        public string UrunVideo { get; set; }

        public int KategoriID { get; set; }

    }
}
