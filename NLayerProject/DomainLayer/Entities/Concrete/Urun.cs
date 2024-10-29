using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Urun:IEntity 
    {
        public int UrunID { get; set; }

        public string UrunAdi { get; set; }

        public string Acıklama{ get; set; }

        public decimal Fiyat { get; set; }

        public string Resim { get; set; }

        public string UrunVideo { get; set; }

        public int KategoriID { get; set; }


        public DateTime EklenmeTarih { get; set; }

        public DateTime? GuncellenmeTarih { get; set; }

        public DateTime? PasiflestirildiTarih { get; set; }

        public KayıtDurumu KayitDurumu { get; set; }



        //RELATIONAL (Navigation) PROPERTY 

        public Kategorı Kategori { get; set; }

        public ICollection<Sepet> Sepettekiler { get; set; }



    }
}
