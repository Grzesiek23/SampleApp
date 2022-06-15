using MediatR;
using SampleApp.Core.Repositories;

namespace SampleApp.Application.Features.Client.Queries;


public record AllClientsQuery : IRequest<IReadOnlyList<Core.Models.Client>>;

public class AllClientsQueryHandler : IRequestHandler<AllClientsQuery, IReadOnlyList<Core.Models.Client>>
{
    private readonly IClientRepository _clientRepository;

    public AllClientsQueryHandler(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<IReadOnlyList<Core.Models.Client>> Handle(AllClientsQuery request, CancellationToken cancellationToken)
    {
        var output = await _clientRepository.GetAllAsync(cancellationToken);
        return output;
    }
}