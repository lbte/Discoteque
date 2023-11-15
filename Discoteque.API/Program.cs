using Discoteque.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Discoteque.Infrastructure.Extensions;
using Discoteque.API.Middlewares.Exceptions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DiscotequeContext>(
    opt => { opt.UseInMemoryDatabase("Discoteque"); }
);

// dependency injection
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();
builder.Services.AddPublishers(builder.Configuration);

// HealthCheck for confirmation that the app can communicate with a DB configured with EFCore DbContext
builder.Services.AddHealthChecks()
    .AddDbContextCheck<DiscotequeContext>();

var app = builder.Build();

PopulateDatabase.ExecuteAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();