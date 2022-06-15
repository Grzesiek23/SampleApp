using Microsoft.EntityFrameworkCore;
using SampleApp.Core.Models;
using SampleApp.Core.Repositories;
using SampleApp.Infrastructure.Contexts;

namespace SampleApp.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IDbContextFactory<SampleDbContext> _dbContextFactory;
    
    public ClientRepository(IDbContextFactory<SampleDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Client> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        
        return ctx.Clients.FirstOrDefault(x => x.Id == id);
        
    }

    public async Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await using var ctx = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await ctx.Clients.ToListAsync(cancellationToken);
    }
}