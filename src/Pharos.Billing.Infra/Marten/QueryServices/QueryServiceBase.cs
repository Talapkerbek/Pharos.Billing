using Marten;

namespace Pharos.Billing.Infra.Marten.QueryServices;

public abstract class QueryServiceBase<T>(IDocumentSession session) where T : notnull
{
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await session.Query<T>().ToListAsync();
    } 
}