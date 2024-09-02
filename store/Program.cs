using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var mycon = builder.Configuration.GetConnectionString("mycon");
            builder.Services.AddDbContext<AppDbcontext>(x=>x.UseSqlServer(mycon));

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddIdentity<AppUser,IdentityRole>()
                .AddEntityFrameworkStores<AppDbcontext>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=GameStore}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
