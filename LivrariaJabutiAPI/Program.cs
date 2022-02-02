using LivrariaJabutiAPI.Infrastructure;
using LivrariaJabutiAPI.Web.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// DbConnection Region
#region DbConnection
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion

// Add Domain Services Region
#region DomainServices
builder.Services.AddTransient<ErrorHandlerMiddleware>();
#endregion

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

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.MapControllers();

app.Run();
