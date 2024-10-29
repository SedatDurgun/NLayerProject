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
    public class Sepet_CFG :Base_CFG<Sepet>  ,IEntityTypeConfiguration<Sepet>
    {
        public void Configure(EntityTypeBuilder<Sepet> builder)
        {

            //    builder.Property(x => x.EklenmeTarih).HasColumnType("smalldatetime");
            //    builder.Property(x => x.GuncellenmeTarih).HasColumnType("smalldatetime");
            //    builder.Property(x => x.PasiflestirildiTarih).HasColumnType("smalldatetime");

            base.Configure(builder);
        }
    }
}
