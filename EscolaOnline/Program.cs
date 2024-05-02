using Microsoft.AspNetCore.Identity;
using EscolaOnline.Data;
using EscolaOnline.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

// Configura��o do Entity Framework e Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura o Identity com as p�ginas de UI padr�o fornecidas pelo pacote Identity UI
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false; // Mude para false para testes sem confirma��o de e-mail
}).AddEntityFrameworkStores<ApplicationDbContext>();

// Adiciona as p�ginas do Identity ao projeto
builder.Services.AddRazorPages();

var app = builder.Build();

// Configura��o de middleware para ambiente de produ��o
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adiciona o middleware de autentica��o e autoriza��o
app.UseAuthentication();
app.UseAuthorization();

// Configura��o de endpoints para habilitar o mapeamento para Razor Pages e Controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages(); // Habilita o mapeamento para Razor Pages, necess�rio para o Identity
});

app.Run();
