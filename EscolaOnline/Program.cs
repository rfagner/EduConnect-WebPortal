using Microsoft.AspNetCore.Identity;
using EscolaOnline.Data;
using EscolaOnline.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllersWithViews();

// Configuração do Entity Framework e Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura o Identity com as páginas de UI padrão fornecidas pelo pacote Identity UI
builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
    options.SignIn.RequireConfirmedAccount = false; // Mude para false para testes sem confirmação de e-mail
}).AddEntityFrameworkStores<ApplicationDbContext>();

// Adiciona as páginas do Identity ao projeto
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuração de middleware para ambiente de produção
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adiciona o middleware de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Configuração de endpoints para habilitar o mapeamento para Razor Pages e Controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages(); // Habilita o mapeamento para Razor Pages, necessário para o Identity
});

app.Run();
