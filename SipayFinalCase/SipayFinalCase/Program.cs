using Api.DataAccess;
using Api.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using AutoMapper;
using Api.Schema.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SipayApiDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
