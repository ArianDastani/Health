using Health.Persistensce.Context;
using Health.Persistensce.Extention;
using Microsoft.EntityFrameworkCore;

namespace Health.Peresentaion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region IoC

            #endregion

            #region Context
            builder.Services.AddDataLeyer();
            #endregion

            #region Autentication

            #endregion

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
	            await next();
	            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
	            {
		            context.Request.Path = "/Erorr404";
		            await next();
	            }
            });

			app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
