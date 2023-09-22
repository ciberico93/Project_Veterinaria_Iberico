using VeterinariaWebApp.ClientMvc.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using VeterinariaWebApp.DataAccess;
using VeterinariaWebApp.DataAccess.Data;
using VeterinariaWebApp.Entities;
using VeterinariaWebApp.Entities.Config_Envio_correos_;
using VeterinariaWebApp.Repositories.Implementaciones;
using VeterinariaWebApp.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Mapeamos la configuracion del appsetting.json como si fuera una clase
builder.Services.Configure<AppConfig>(builder.Configuration);
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"));
});

// Configuracion de ASP.NET Identity
builder.Services
    .AddDefaultIdentity<VeterinariaIdentityUser>(
        options =>
        {
            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedAccount = true;

            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireNonAlphanumeric = false;

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VeterinariaDbContext>()
    .AddDefaultTokenProviders();


// Add services to the container.
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IMascotaRepository, MascotaRepository>();
builder.Services.AddTransient<ICitaRepository,CitaRepository>();
builder.Services.AddTransient<ITipoMascotaRepository, TipoMascotaRepository>();
builder.Services.AddTransient<IServicioRepository, ServicioRepository>();

builder.Services.AddScoped<IFileUploader, FileUploader>();
builder.Services.AddScoped<IEmailSender, EmailService>();


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
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{

    var dbContext = scope.ServiceProvider.GetRequiredService<VeterinariaDbContext>();
    if (dbContext.Database.GetPendingMigrations().Any())
    {
        // Aplica las migraciones de ser necesario
        dbContext.Database.Migrate();
    }

    // Aqui vamos a ejecutar la creacion del usuario admin y los roles por default.
    await UserDataSeeder.Seed(scope.ServiceProvider);
}
app.Run();
