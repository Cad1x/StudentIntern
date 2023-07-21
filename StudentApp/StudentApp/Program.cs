using Application.Mappings;
using Application.Services;
using Application.Services.Abstractions;
using Application.Validators;
using Application.Validators.Abstractions;
using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IStudentRepositiory, StudentRepository>();
builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddScoped<IStudentValidator, StudentValidator>();

builder.Services.AddDbContext<StudentAppContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("StudentCS")));

builder.Services.AddSingleton(AutoMapperConfig.Initialize());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PrductsApp API", Version = "v1" });
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
