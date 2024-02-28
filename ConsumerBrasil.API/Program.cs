using ConsumerBrasil.Application.Interfaces;
using ConsumerBrasil.Application.Profiles;
using ConsumerBrasil.Application.Services;
using ConsumerBrasil.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add services

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IBrasilAPI, BrasilAPIService>();
builder.Services.AddScoped<IBrasilAPIService, ConsumerBrasil.Domain.Services.BrasilAPIService>();
builder.Services.AddAutoMapper(typeof(BancosProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
