using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Abstract
{
    public interface IEntity
    {
        public DateTime EklenmeTarih { get; set; }

        public DateTime? GuncellenmeTarih { get; set; }

        public DateTime? PasiflestirildiTarih { get; set; }

        public KayıtDurumu KayitDurumu { get; set; }

    }
}
