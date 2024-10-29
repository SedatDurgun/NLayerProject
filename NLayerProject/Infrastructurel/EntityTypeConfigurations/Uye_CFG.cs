using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructurel.EntityTypeConfigurations
{
    public class Uye_CFG : IEntityTypeConfiguration<Uye>
    {
        public void Configure(EntityTypeBuilder<Uye> builder)
        {
            builder.Property(x=>x.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Soyad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Adres).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            Uye uye = new Uye()
            {
                Id = 1,
                Ad = "Super",
                Soyad = "Admin",
                Adres ="Ankara",
                UserName = "superAdmin",
                NormalizedUserName = "SuperAdmin",  
                Email = "superadmin@deneme.com",
                NormalizedEmail = "SuperAdmin@deneme.com",
                SecurityStamp = Guid.NewGuid().ToString(), // 
                ConcurrencyStamp = Guid.NewGuid().ToString(), // aynı kayıt olup olmadığını kontrol ediyoruz
                EmailConfirmed = false,
            };

            PasswordHasher<Uye> hasher = new PasswordHasher<Uye>();
            uye.PasswordHash = hasher.HashPassword(uye, "superadmin123"); 

            builder.HasData(uye);

            


        }
    }
}
