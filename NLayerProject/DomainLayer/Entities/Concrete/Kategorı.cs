using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Kategorı:IEntity
    {

        public int KategorıID { get; set; }

        public string KategoriAdi { get; set; }


        public DateTime EklenmeTarih { get; set; }

        public DateTime? GuncellenmeTarih { get; set; }

        public DateTime? PasiflestirildiTarih { get; set; }

        public KayıtDurumu KayitDurumu { get; set; }


        // RELATIONAL PROPERTY



        public ICollection<Urun> Urunler { get; set; }


    }
}
