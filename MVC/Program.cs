using Entidades.Models;
using Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<LahigueraContext>();
builder.Services.AddTransient<IPacienteService, PacienteService>();
builder.Services.AddTransient<IAntecedenteService, AntecedenteService>();
builder.Services.AddTransient<IComplementarioService, ComplementarioService>();
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
