using BookShopData.Extensions;
using BookShopService.Extensions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
        builder.Services.LoadDataLayerExtension(builder.Configuration);
        builder.Services.LoadServiceLayerExtension();
        builder.Services.AddLocalization(opt =>
        {
            opt.ResourcesPath = "Resources";
        });


        var app = builder.Build();
        app.UseRequestLocalization();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        var supportedCulture = new[] { "en", "tr", "ru", "az" };
        var localizationOption = new RequestLocalizationOptions().SetDefaultCulture(supportedCulture[3]).AddSupportedUICultures(supportedCulture).AddSupportedUICultures(supportedCulture);
        app.UseRequestLocalization(localizationOption);

        app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
      );
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}