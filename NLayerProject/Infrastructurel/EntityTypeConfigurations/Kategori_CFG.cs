using DomainLayer.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructurel.EntityTypeConfigurations
{
    public class Kategori_CFG : Base_CFG<Kategorı> , IEntityTypeConfiguration<Kategorı>
    {
        public void Configure(EntityTypeBuilder<Kategorı> builder)
        {


            builder.Property(x=>x.KategoriAdi).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            //builder.Property(x => x.EklenmeTarih).HasColumnType("smalldatetime");
            //builder.Property(x => x.GuncellenmeTarih).HasColumnType("smalldatetime");
            //builder.Property(x => x.PasiflestirildiTarih).HasColumnType("smalldatetime"); ;
            base.Configure(builder);
            builder.HasData(
                new Kategorı { 
                KategorıID=1,
                EklenmeTarih=DateTime.Now ,
                KayitDurumu=DomainLayer.Enums.KayıtDurumu.Aktif,
                KategoriAdi="Elektronik ",
               
                },

                new Kategorı
                {
                    KategorıID = 2,
                    EklenmeTarih=DateTime.Now ,
                    KayitDurumu=DomainLayer.Enums.KayıtDurumu.Aktif,
                    KategoriAdi="Hediyelik Eşya "
                },

                new Kategorı
                {
                    KategorıID=3,
                    EklenmeTarih=DateTime.Now ,
                    KayitDurumu=DomainLayer.Enums.KayıtDurumu.Aktif,
                    KategoriAdi=" Hobi "
                }
                
                );

        }

    }
}
