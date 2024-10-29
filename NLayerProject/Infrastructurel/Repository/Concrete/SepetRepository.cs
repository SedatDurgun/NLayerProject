using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Infrastructurel.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructurel.Repository.Concrete
{
    public class SepetRepository : BaseRepository<Sepet>, ISepetRepostory
    {
        public SepetRepository(UrunContext db) : base(db)
        {
        }
    }
}
