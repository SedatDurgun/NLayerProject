using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Uye : IdentityUser<int> 
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }

        // RELATIONAL PROPERTY
        public ICollection<Sepet> Sepettekiler { get; set; }
    }
}
