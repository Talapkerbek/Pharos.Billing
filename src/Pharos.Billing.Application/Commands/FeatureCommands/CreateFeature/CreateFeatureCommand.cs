using Pharos.Billing.Domain.Aggregates.Feature;
using Pharos.Billing.Domain.Common;

namespace Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;

public record CreateFeatureCommand(string Name, Money BasePrice, FeatureType FeatureType);