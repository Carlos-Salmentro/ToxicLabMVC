using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ToxicLab.CasosDeUso.Clientes;
using ToxicLab.InfraEstrutura.Repositorio;

var builder = WebApplication.CreateBuilder(args);


//Para trabalhar com controllers
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddScoped<AdicionarClienteHandler>();
builder.Services.AddScoped<DeletarClienteHandler>();
builder.Services.AddScoped<MostrarClientesHandler>();
builder.Services.AddScoped<BuscarClientePorIdHandler>();

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

//*** como mapear os EndPoints? ***
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication(); //add tentando solucionar falta de certificado
app.UseAuthorization();


//para trabalhar com controllers
app.MapControllers();

app.Run();
