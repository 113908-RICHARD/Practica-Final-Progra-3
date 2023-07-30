using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using practicaFinal.Buisness;
using practicaFinal.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<GetEmpleadosBuisness>());
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<PostEmpleadoBuisness>());
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<GetCargosBuisness>());
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<GetSucursalesBuisness>());
builder.Services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<getJefesBuisness>());
builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDataBase"));
});
builder.Services.AddMediatR(typeof(GetEmpleadosBuisness.Manejador).Assembly);
builder.Services.AddMediatR(typeof(PostEmpleadoBuisness.Manejador).Assembly);
builder.Services.AddMediatR(typeof(GetCargosBuisness.Manejador).Assembly);
builder.Services.AddMediatR(typeof(GetSucursalesBuisness.Manejador).Assembly);
builder.Services.AddMediatR(typeof(getJefesBuisness.Manejador).Assembly);
builder.Services.AddCors();


var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyOrigin();
    c.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
