using SampleApp.Core.Models;

namespace SampleApp.Core.Repositories;

public interface IClientRepository
{
    Task<Client> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Client>> GetAllAsync(CancellationToken cancellationToken = default);
}