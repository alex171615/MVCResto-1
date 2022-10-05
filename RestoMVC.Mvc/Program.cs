using RestoMVC.AdoET12;
using et12.edu.ar.AGBD.Ado;
using RestoMVC.Core;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<AdoAGBD>(sAdoRestoMVC => FactoryAdoAGBD.GetAdoMySQL("appSettings.json", "test"));
builder.Services.AddTransient<IAdo, AdoRestoMVC>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
