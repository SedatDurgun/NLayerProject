using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Sepet:IEntity
    {

        public int SepetID { get; set; }
        public int UyeID { get; set; }
        public int UrunID { get; set; }
        public int  Adet { get; set; }


        public DateTime EklenmeTarih { get; set; }

        public DateTime? GuncellenmeTarih { get; set; }

        public DateTime? PasiflestirildiTarih { get; set; }

        public KayıtDurumu KayitDurumu { get; set; }


        //Relatınoal Property
        public Uye Uye { get; set; }

        public Urun Urun { get; set; }

        


    }
}
