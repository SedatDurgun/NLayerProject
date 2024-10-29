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
    public class Urun_CFG :Base_CFG<Urun>,IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.Property(x => x.UrunAdi).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Acıklama).HasColumnType("varchar").HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.Fiyat).HasColumnType("money").IsRequired();
            builder.Property(x => x.Resim).HasColumnType("varchar").HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.UrunVideo).HasColumnType("varchar").IsRequired(false).HasMaxLength(100);

            base.Configure(builder);


            //    builder.Property(x => x.EklenmeTarih).HasColumnType("smalldatetime");
            //    builder.Property(x => x.GuncellenmeTarih).HasColumnType("smalldatetime");
            //    builder.Property(x => x.PasiflestirildiTarih).HasColumnType("smalldatetime");
            }
        }
    }

