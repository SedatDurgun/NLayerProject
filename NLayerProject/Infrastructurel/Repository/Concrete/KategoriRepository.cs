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
    public class KategoriRepository : BaseRepository<Kategorı>,IKategorıRepostory
    {
        public KategoriRepository(UrunContext db) : base(db)
        {
        }
    }
}
