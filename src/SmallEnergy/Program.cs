using AccesPoint.Models;
using AccesPoint.Inferfaces;
using AccesPoint.SqlDataAccess;
using AccesPoint.Users;
using Microsoft.AspNetCore.Identity;
using SmallEnergy.Auth;

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

            builder.Services.AddIdentity<User, UserRole>()
                 .AddUserStore<UserStore>()
                 .AddRoleStore<RoleStore>()
                 .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth";
            });

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

            app.UseHttpsRedirection();
            // app.UseStaticFiles();
            app.UseFileServer();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
