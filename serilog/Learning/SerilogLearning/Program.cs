
// >>> Serilog ------------------------------------------------------------------------------------------

using Serilog;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config).CreateLogger();

// ------------------------------------------------------------------------------------------ Serilog <<<

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// >>> Serilog ------------------------------------------------------------------------------------------

builder.Host.UseSerilog();

// ------------------------------------------------------------------------------------------ Serilog <<<

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// >>> Serilog ------------------------------------------------------------------------------------------

try
{
    Log.Information("API inicializando");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplicação falhou ao iniciar");
}
finally
{
    Log.CloseAndFlush();
}

// ------------------------------------------------------------------------------------------ Serilog <<<
