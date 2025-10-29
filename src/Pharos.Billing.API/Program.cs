using Pharos.Billing.API.HostedServices;
using Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;
using Pharos.Billing.Domain.DomainServices;
using Pharos.Billing.Infra.Logging;
using Pharos.Billing.Infra.Marten;
using Pharos.Billing.Infra.Marten.QueryServices;
using Pharos.Billing.Infra.Repositories;
using Pharos.Billing.Infra.Stripe;
using Pharos.Billing.Infra.Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAndConfigureSerilog(builder.Configuration)
    .AddAndConfigureMarten(builder.Configuration)
    .AddStripe(builder.Configuration)
    .AddRepositories()
    .AddDomainServices()
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
