using ArticleApp.EntityFramework.Context;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
//
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
// Add services to the container.
builder.Services.AddControllersWithViews();
//Configure DataBase Connection
builder.Services.AddDbContext<DataContext>(options =>
{
     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
          sqlServerOptionsAction: sqlOptions =>
          {
               sqlOptions.MigrationsAssembly(typeof(DataContext).Assembly.FullName); // Specify the correct assembly name
          });
});
//Change Views Path
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
     options.ViewLocationFormats.Clear();
     // Add the root path where your custom views are located
     options.ViewLocationFormats.Add("/UI/Shared/{0}" + RazorViewEngine.ViewExtension);
     options.ViewLocationFormats.Add("/UI/{1}/{0}" + RazorViewEngine.ViewExtension);

});
//Add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
     options.IdleTimeout = TimeSpan.FromMinutes(10);
});
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
