using BusTrackingSimulator.Services;
using BusTrackingSimulator.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IBusTrackerService, BusTrackerService>();

var app = builder.Build();

// Enable CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();
app.Run();
