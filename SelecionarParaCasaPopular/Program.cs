using SelecionarParaCasaPopular.Data.DataContext;
using SelecionarParaCasaPopular.Data.Profiles;
using SelecionarParaCasaPopular.Services;
using SelecionarParaCasaPopular.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FamiliasContext>();
builder.Services.AddScoped<IFamiliaService, FamiliaService>();
builder.Services.AddScoped<ICalculadorService, CalculadorService>();
builder.Services.AddAutoMapper(typeof(FamiliaProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
