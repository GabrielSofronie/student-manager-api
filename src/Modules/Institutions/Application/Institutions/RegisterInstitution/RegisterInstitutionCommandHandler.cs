using Common.Application.Handlers;
using Institutions.Domain.Institutions;

namespace Institutions.Application.Institutions.RegisterInstitution;

public sealed class RegisterInstitutionCommandHandler : ICommandHandler<RegisterInstitutionCommand, Guid>
{
    private readonly IInstitutionRepository _institutionRepository;

    public RegisterInstitutionCommandHandler(IInstitutionRepository institutionRepository)
    {
        _institutionRepository = institutionRepository;
    }

    public async Task<Guid> Handle(RegisterInstitutionCommand request, CancellationToken cancellationToken)
    {
        var institution = Institution.Create(request.Email, request.Password, request.Name, request.Code, request.City, request.Address, request.Ownership);

        var result = await Insert(institution);

        return result == 1 ? institution.Id.Id : Guid.Empty;
    }

    private async Task<int> Insert(Institution institution)
    {
        try
        {
            await _institutionRepository.AddAsync(institution);
            return await _institutionRepository.Commit();
        }
        catch (Exception ex)
        {
            // TODO: Treat exception
            return 0;
        }
    }
}