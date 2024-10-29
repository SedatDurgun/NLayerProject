using DomainLayer.Entities.Abstract;
using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructurel.Repositories.Concrete
{
    public class BaseRepository<TEntity> : IBaseRepositorycs<TEntity> where TEntity : class, IEntity
    {
        private readonly UrunContext _db;
        protected DbSet<TEntity> _table;


        public BaseRepository( UrunContext db)
        {
            _db = db;
            _table = db.Set<TEntity>();  
        }


        public async Task<TEntity> AraAsync(int id)
        {

            //id'gelen kaydın kendisini dondurur
          return await  _table.FindAsync(id);
        }

        public async Task EkleAsync(TEntity entity)
        {
            //Tabloya ekleme yapmak için kullanılır 
            entity.EklenmeTarih=DateTime.Now;
            entity.KayitDurumu = DomainLayer.Enums.KayıtDurumu.Aktif;
            



             await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> GüncelleAsync(TEntity entity)
        {
            //Tarih hatasından dolayı bu yazıldı
            entity.EklenmeTarih= DateTime.Now;
            entity.GuncellenmeTarih= DateTime.Now;
            entity.PasiflestirildiTarih= DateTime.Now;

           entity.GuncellenmeTarih = DateTime.Now;
            entity.KayitDurumu = DomainLayer.Enums.KayıtDurumu.Güncellendi;
           
            _db.Update(entity);//update metodu async olmadığından await yazılmadı
            return await _db.SaveChangesAsync()> 0;
        }

        public async Task<bool> SilAsync(int id)
        {
            TEntity entity= await AraAsync(id);
           entity.PasiflestirildiTarih= DateTime.Now;
            entity.KayitDurumu = DomainLayer.Enums.KayıtDurumu.Pasif;
            
            _table.Update(entity);
            return await _db.SaveChangesAsync()> 0;
        }

        public async Task<IEnumerable<TEntity>> TumAktifleriListeleAsync()
        {
            //Kayıt durumu Aktif yada güncellenmiş olan...
            return await _table.Where(x=>x.KayitDurumu != DomainLayer.Enums.KayıtDurumu.Pasif).ToListAsync(); // Tüm Aktif Kategorileri listele 
        }

        public IQueryable<TEntity>TumAktifleriListeleInclude()
        {
            return _table.Where(x => x.KayitDurumu != DomainLayer.Enums.KayıtDurumu.Pasif);
        }

        public async Task<IEnumerable<TEntity>> TumPasifleriListeleAsync()
        {
            //Kayıt durumu pasif olan...
            return await _table.Where(x=>x.KayitDurumu==DomainLayer.Enums.KayıtDurumu.Pasif).ToListAsync();
        }

    }
}
