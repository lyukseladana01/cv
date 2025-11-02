internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
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
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Cv}/{action=Index}/{id?}")
            .WithStaticAssets();
        // Rotativa ayarı
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS0612 // Type or member is obsolete
//        object value = RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)app.Services.GetService(typeof(Microsoft.AspNetCore.Hosting.IHostingEnvironment)));
#pragma warning restore CS0612 // Type or member is obsolete
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        app.Run();
    }
}

internal class RotativaConfiguration
{
    [Obsolete]
    internal static object Setup(Microsoft.AspNetCore.Hosting.IHostingEnvironment? hostingEnvironment)
    {
        throw new NotImplementedException();
    }
}