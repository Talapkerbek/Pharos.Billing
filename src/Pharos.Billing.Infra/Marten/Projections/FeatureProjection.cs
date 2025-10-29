using JasperFx.Events;
using Marten.Events.Aggregation;
using Pharos.Billing.Domain.Aggregates.Feature.Events;
using Pharos.Billing.Infra.Marten.ReadModels;

namespace Pharos.Billing.Infra.Marten.Projections;

public class FeatureProjection : SingleStreamProjection<FeatureReadModel, Guid>
{
    public FeatureReadModel Create(IEvent<FeatureCreatedEvent> @event)
    {
        var trip = new FeatureReadModel()
        {
            Id = @event.StreamId,
            Name = @event.Data.Name
        };

        return trip;
    }
    
    public void Apply(FeatureReadModel model, IEvent<FeatureNameChangedEvent> @event)
    {
        model.Name = @event.Data.Name;
    }
}