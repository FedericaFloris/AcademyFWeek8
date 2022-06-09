using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.InterfaceRepository;
using AcademyFWeek8.MVC.EsempioCounter;
using AcademyFWeek8.RepositoryEF;
using AcademyFWeek8.RepositoryMOCK;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configurazione della DipendenceInjection--> creo i collegamenti
builder.Services.AddScoped<IBusinessLayer, MainBusinessLayer>(); //ogni volta che trovi un oggetto di ImainBusinessLayer devi utilizzare un istanza di MainBusinessLayer
//DI-->gli dico cosa deve usare al posto dell interfaccia
builder.Services.AddScoped<IRepositoryCorsi, RepositoryCorsiEF>();
builder.Services.AddScoped<IRepositoryStudenti, RepositoryStudentiEF>();
builder.Services.AddScoped<IRepositoryDocenti, RepositoryDocentiEF>();
builder.Services.AddScoped<IRepositoryLezioni, RepositorylezioniEF>();
builder.Services.AddScoped<IRepositoryUtenti, RepositoryUtentiEF>();

//builder.Services.AddTransient<ICounter, Counter>();
//builder.Services.AddScoped<ICounter, Counter>();
builder.Services.AddSingleton<ICounter, Counter>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    option =>
    {
        option.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Login");
        option.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Utenti/Forbidden");

    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adm", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
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

app.UseRouting();

app.UseAuthentication(); // l'ordine è importante
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
