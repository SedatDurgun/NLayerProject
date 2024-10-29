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
    public class UrunRepository : BaseRepository<Urun>, IUrunRepository
    {
        //Generate  CTOR ile implement et 
        public UrunRepository(UrunContext db) : base(db)
        {
        }

        public object TumAktifleriListelAsync()
        {
            throw new NotImplementedException();
        }
    }
}
