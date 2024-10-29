using DomainLayer.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructurel.EntityTypeConfigurations
{
    public abstract class Base_CFG<TEntity> where TEntity : class, IEntity
    {
        protected void Configure(EntityTypeBuilder<TEntity> builder)
        {

            builder.Property(x => x.EklenmeTarih).HasColumnType("smalldatetime").IsRequired(true);
            builder.Property(x => x.GuncellenmeTarih).HasColumnType("smalldatetime").IsRequired(false);
            builder.Property(x => x.PasiflestirildiTarih).HasColumnType("smalldatetime").IsRequired(false);
        }
    }
}

 
