using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.ViewModels
{
    public class SepetVM
    {
        public int SepetID { get; set; }
        public int UyeID { get; set; }

        public int UrunID { get; set; }

        public string UrunAdi { get; set; }
        public int Adet { get; set; }
    }
}
