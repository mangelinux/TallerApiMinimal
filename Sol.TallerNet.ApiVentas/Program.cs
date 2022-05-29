using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Applications;
using Sol.TallerNet.ApiVentas.Model.Extensions;
using Sol.TallerNet.ApiVentas.Model.Mappers;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

var builder = WebApplication.CreateBuilder(args);
var conexion = builder.Configuration.GetConnectionString("MyBD");
builder.Services.AddDbContext<TallerContext>(opt =>
{
    opt.UseSqlServer(conexion);
});

builder.Services.AddInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperDto));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddOperation();

app.Run();

