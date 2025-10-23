using AccesPoint.Models;
using AccesPoint.Inferfaces;
using AccesPoint.SqlDataAccess;
using AccesPoint.Users;
using Microsoft.AspNetCore.Identity;
using SmallEnergy.Auth;
using SmallEnergy.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using SmallEnergy.Helpers;

namespace SmallEnergy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserData, UserData>();
            builder.Services.AddScoped<ISearch, Search>();
            builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddScoped<IPagination, Pagination>();

            builder.Services.AddIdentity<User, UserRole>()
                 .AddUserStore<UserStore>()
                 .AddRoleStore<RoleStore>()
                 .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth";
            });

            builder.Services.AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@"/keys/"))
                .SetApplicationName("myapp");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePagesWithReExecute("/Shared/Error{0}");

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy",
                    "default-src 'self'; " +
                    "script-src 'self'; " +
                    "style-src 'self'; " +
                    "img-src 'self'; " +
                    "font-src 'self'; " +
                    "connect-src 'self'; " +
                    "frame-ancestors 'self'; " +
                    "base-uri 'self';"
                );
            
                await next();
            });
            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseFileServer();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
