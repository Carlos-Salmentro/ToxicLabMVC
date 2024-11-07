using Microsoft.EntityFrameworkCore;
using ToxicLabMVC.InfraEstrutura.Repositorio;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var stringConexao = builder.Configuration.GetConnectionString("ToxicLabString");
    options.UseMySql(ServerVersion.AutoDetect(stringConexao));
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
