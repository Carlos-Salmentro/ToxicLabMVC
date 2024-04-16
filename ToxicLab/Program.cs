using Microsoft.EntityFrameworkCore;
using ToxicLab.InfraEstrutura.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add banco de dados como serviço.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var stringDeConexao = builder.Configuration.GetConnectionString("ToxicLabString");
    options.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
