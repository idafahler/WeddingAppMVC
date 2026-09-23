using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WeddingAppMVC.Data;
using WeddingAppMVC.Services;

namespace WeddingAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var culture = new CultureInfo("en-GB");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IGuestService, GuestService>();
            builder.Services.AddScoped<IEventService, EventService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
