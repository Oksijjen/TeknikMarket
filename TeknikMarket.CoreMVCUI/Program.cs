using FluentValidation;
using FluentValidation.AspNetCore;
using Newtonsoft.Json;
using TeknikMarket.Business.Abstract;
using TeknikMarket.Business.Concrete;
using TeknikMarket.Business.ValidationRule.Areas.Admin;
using TeknikMarket.CoreMVCUI.Areas.Admin.Filter;
using TeknikMarket.DataAccess.Abstract;
using TeknikMarket.DataAccess.Concrete.EntityFramework.repository;
using TeknikMarket.Model.ViewModel.Areas.Admin;

namespace TeknikMarket.CoreMVCUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                
            });

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            //AUTOMAPPER
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            //builder.Services.AddTransient(); ÝSTEDÝÐÝN KADAR NEWLÝYOR HER TALEPTE NEW ÝÞLEMÝNÝ TEKRAR YAPIYOR
            //builder.Services.AddScoped();    SADECE 1 SCOPEDA GEÇERLÝ OLUYOR SONRA ÖLÜYOR
            //builder.Services.AddSingleton(); SADECE 1 KERE KULLANIYOR.TALEP EDÝLDÝÐÝNDE BUNU TEKRAR KULLANIYOR

            builder.Services.AddSingleton<IKullaniciBS, KullaniciBs>();
            builder.Services.AddSingleton<IKullaniciRepository, EFKullaniciRepository>();
            builder.Services.AddSingleton<IKategoriBS, KategoriBs>();
            builder.Services.AddSingleton<IKategoriRepository, EFKategoriRepository>();
            builder.Services.AddSingleton<IUrunBS, UrunBs>();
            builder.Services.AddSingleton<IUrunRepository, EfUrunRepository>();
            builder.Services.AddSingleton<IUrunFotografBS, UrunFotografBs>();
            builder.Services.AddSingleton<IUrunFotografRepository, EFUrunFotografRepository>();
            builder.Services.AddSingleton<IUrunFiyatBS, UrunFiyatBs>();
            builder.Services.AddSingleton<IUrunFiyatRepository, EFUrunFiyatRepository>();
            builder.Services.AddSingleton<IBankaBS, BankaBS>();
            builder.Services.AddSingleton<IBankaRepository, EFBankaRepository>();

            //SESSION
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(5);
                //5 dakika hiç bir iþlem yapmadan beklersen seni sistem otomatik olarak dýþarý atar session sýfýrlanýr.
            });
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<ISessionManager,SessionManager>();

            //-----VALIDATION
            builder.Services.AddSingleton<IValidator<LogInVm>, LogInVmValidator>();
            builder.Services.AddSingleton<IValidator<ForgotPasswordViewModel>, ForgotPasswordValidator>();
            builder.Services.AddSingleton<IValidator<UpdatePasswordViewModel>, UpdatePasswordValidator>();



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

            app.UseSession();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoint.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}