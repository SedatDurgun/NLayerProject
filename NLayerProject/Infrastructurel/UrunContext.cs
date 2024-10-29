using DomainLayer.Entities.Concrete;
using Infrastructurel.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructurel
{
    public class UrunContext:IdentityDbContext<Uye,Rol,int> 
    {
        public UrunContext() 
        {
         
        }

        public UrunContext(DbContextOptions options ) : base( options ) 
        {


        }
       
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategorı> Kategoriler { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Rol> Roller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data source=SEDAT\\SQLEXPRESS;initial catalog=Ornek_KatmanDB; integrated security=true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration(new Urun_CFG());
            builder.ApplyConfiguration(new Uye_CFG());
            builder.ApplyConfiguration(new Rol_CFG());
            builder.ApplyConfiguration(new Sepet_CFG());
            builder.ApplyConfiguration(new Kategori_CFG());

            //SuperUser- Admin ilişkisi(1-1)
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                UserId=1,
                RoleId=1
            });

            
        }



    }

}
