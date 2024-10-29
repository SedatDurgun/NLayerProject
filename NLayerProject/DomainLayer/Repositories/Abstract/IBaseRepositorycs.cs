using DomainLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repositories.Abstract
{
    public interface IBaseRepositorycs <TEntity> where TEntity: class,IEntity
    {
        Task EkleAsync(TEntity entity);

        Task<bool> GüncelleAsync(TEntity entity);

        Task<bool> SilAsync(int id);

        Task<TEntity> AraAsync(int id);

        // Task<IEnumerable<TEntity>> TumunuListeleAsync();

        
        Task<IEnumerable<TEntity>> TumAktifleriListeleAsync();
        //Softdelete yaptığımız ürünler
        Task<IEnumerable<TEntity>> TumPasifleriListeleAsync();




        

        //IQueryable INCLUD() 

       IQueryable<TEntity>TumAktifleriListeleInclude();



    }
}
