using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));

connectionBuilder.Username = connectionBuilder.Username ?? builder.Configuration["Connection:DefaultConnection:UserId"];
connectionBuilder.Password = connectionBuilder.Password ?? builder.Configuration["Connection:DefaultConnection:Password"];

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionBuilder.ConnectionString));

builder.Services.AddControllers();
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
