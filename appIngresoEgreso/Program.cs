using appIngresoEgreso.Dao;
using appIngresoEgreso.Dao.Impl;
using appIngresoEgreso.Models;
using appIngresoEgreso.Services;
using appIngresoEgreso.Services.Impl;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);


// Agregar servicios para MVC
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoriaDao,CategoriaDao>();
builder.Services.AddScoped<IDahsboardDao, DashboardDao>();
builder.Services.AddScoped<IGastoDao, GastoDao>();
builder.Services.AddScoped<IMiembroDao, MiembroDao>(); 
builder.Services.AddScoped<IUsuarioDao, UsuarioDao>();
builder.Services.AddScoped<IIngresoDao, IngresoDao>();
builder.Services.AddScoped<IPagoDao, PagoDao>();
builder.Services.AddScoped<IServicioDao, ServicioDao>();

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IMiembroService, MiembroService>();
builder.Services.AddScoped<IGastoService, GastoService>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddScoped<IIngresoService, IngresoService>();
builder.Services.AddScoped<IPagoServicioService, PagoServicioService>();
builder.Services.AddScoped<IServicioService, ServicioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });
builder.Services.AddAuthorization();
var app = builder.Build();

// Configuración del pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
