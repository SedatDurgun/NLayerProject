using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTO_s
{
    public class YeniUyeDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string KullanıcıAdı { get; set; }
        public string Eposta { get; set; }

        public string Sifre { get; set; }

        public string Adres { get; set; }
    }
}
