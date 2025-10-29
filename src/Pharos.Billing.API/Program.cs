using Pharos.Billing.API.HostedServices;
using Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;
using Pharos.Billing.Infra.Marten;
using Pharos.Billing.Infra.Marten.QueryServices;
using Pharos.Billing.Infra.Repositories;
using Pharos.Billing.Infra.Wolverine;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information() // Default minimum level
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .MinimumLevel.Override("Marten", LogEventLevel.Warning)
    .MinimumLevel.Override("Wolverine", LogEventLevel.Warning) 
    .MinimumLevel.Override("Npgsql", LogEventLevel.Warning) 
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
        theme: AnsiConsoleTheme.Sixteen 
    )
    .CreateLogger();

builder.Services.AddSerilog();

builder.Services.AddAndConfigureMarten(builder.Configuration);
builder.Services
    .AddRepositories()
    .AddQueryServices();

builder.Services.AddHostedService<RebuildProjectionHostedService>();

builder.Host.AddWolverineWithAssemblyDiscovery(builder.Configuration, [typeof(CreateFeatureHandler).Assembly]);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
