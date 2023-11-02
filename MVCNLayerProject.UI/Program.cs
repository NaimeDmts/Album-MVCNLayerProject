using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCNLayerProject.BLL.Services.AlbumServices;
using MVCNLayerProject.BLL.Services.AppUserServices;
using MVCNLayerProject.BLL.Services.SanatciServices;
using MVCNLayerProject.BLL.Services.TurServices;
using MVCNLayerProject.CORE.Entities;
using MVCNLayerProject.DAL.Contexts;
using MVCNLayerProject.DAL.Repositories.Abstraction;
using MVCNLayerProject.DAL.Repositories.Concrete;

namespace MVCNLayerProject.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var conn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(conn);
                opt.UseLazyLoadingProxies();
            });
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //Password
                options.Password.RequireDigit = false;//En az bir rakam
                options.Password.RequiredLength = 3;//Minimum uzunluk
                options.Password.RequireLowercase = false;//en az bir k���k harf
                options.Password.RequireUppercase = false;//en az bir b�y�k
                options.Password.RequireNonAlphanumeric = false;//en az bir sembol

                //User
                options.User.RequireUniqueEmail = true;//Eposta adresi benzersiz olmal�.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                //SignIn
                options.SignIn.RequireConfirmedEmail = false;//Eposta onay� gerekli olsun mu
                options.SignIn.RequireConfirmedPhoneNumber = false;//Telefon onay�
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
            builder.Services.AddScoped<ISanatciRepository, SanatciRepository>();
            builder.Services.AddScoped<ITurRepository, TurRepository>();

            builder.Services.AddTransient<IAlbumService, AlbumService>();
            builder.Services.AddTransient<ITurService,TurService>();
            builder.Services.AddTransient<ISanatciService, SanatciService>();
            builder.Services.AddTransient<IAppUserService, AppUserService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}