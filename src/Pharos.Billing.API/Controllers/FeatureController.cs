using Microsoft.AspNetCore.Mvc;
using Pharos.Billing.Application.Commands.FeatureCommands.ChangeName;
using Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;
using Pharos.Billing.Application.Queries.FeatureQueries.GetAll;
using Pharos.Billing.Infra.Marten.ReadModels;
using Wolverine;

namespace Pharos.Billing.API.Controllers;

[ApiController]
[Route("feature")]
public class FeatureController(IMessageBus bus) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeatureReadModel>>> GetAllFeatures()
    {
        var command = new GetAllFeaturesQuery();
        return Ok(await bus.InvokeAsync<IReadOnlyCollection<FeatureReadModel>>(command));
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateFeature([FromBody] CreateFeatureCommand command)
    {
        await bus.InvokeAsync(command);
        return Ok();
    }
    
    [HttpPut("name")]
    public async Task<ActionResult> CreateFeature([FromBody] ChangeFeatureNameCommand command)
    {
        await bus.InvokeAsync(command);
        return Ok();
    }
}