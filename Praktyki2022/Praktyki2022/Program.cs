using Microsoft.EntityFrameworkCore;
using Praktyki2022.Controllers;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/////////////////////////////////////////////////////////////////////////////


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//var configuration = new ConfigurationBuilder()
//       .SetBasePath(Directory.GetCurrentDirectory())
//       .AddJsonFile("appsettings.json")
//       .Build();

//var connectionString = configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<StudentController>();
builder.Services.AddControllers();
/////////////////////////////////////////////////////////////////////////////////

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
