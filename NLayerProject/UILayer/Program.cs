using ApplicationLayer.AutoMapper;
using ApplicationLayer.Services.KategoriService;
using ApplicationLayer.Services.SepetService;
using ApplicationLayer.Services.UrunService;
using ApplicationLayer.Services.UserService;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Infrastructurel;
using Infrastructurel.Repository.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//IoC
//

//Veritabaný
builder.Services.AddDbContext<UrunContext>(x=>x.UseSqlServer());

//Identiy

builder.Services.AddIdentity<Uye,Rol>(x=>x.SignIn.RequireConfirmedAccount=false).AddEntityFrameworkStores<UrunContext>().AddRoles<Rol>();

//AutoMapper

builder.Services.AddAutoMapper(x => x.AddProfile(typeof(UrunProjeMapper)));


//Repositories

builder.Services.AddTransient<IUrunRepository, UrunRepository>();
builder.Services.AddTransient<IKategorýRepostory, KategoriRepository>();
builder.Services.AddTransient<ISepetRepostory, SepetRepository>();



//AddSingLeton()...
//AddScoped()...
//AddTransient()...

//SERVIS.
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUrunService, UrunService>();
builder.Services.AddTransient<IKategoriService, KategoriService>();
builder.Services.AddTransient<ISepetService, SepetService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=AdminPanel}/{action=Index}/{id?}"
    );
});

//User Panel
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=UyePanel}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
