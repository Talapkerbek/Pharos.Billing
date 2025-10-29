using JasperFx.Events;
using Marten;
using Marten.Events.Aggregation;
using Marten.Events.Projections;
using Pharos.Billing.Domain.Feature;
using Pharos.Billing.Domain.Feature.Events;
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