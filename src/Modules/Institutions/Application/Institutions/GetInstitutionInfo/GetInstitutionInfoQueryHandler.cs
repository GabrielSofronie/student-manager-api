using Common.Application.Exceptions;
using Common.Application.Handlers;
using Institutions.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Institutions.Application.Institutions.GetInstitutionInfo;

public sealed class GetInstitutionInfoQueryHandler : IQueryHandler<GetInstitutionInfoQuery, InstitutionInfoDto>
{
    private readonly IInstitutionsDbContext _ctx;

    public GetInstitutionInfoQueryHandler(IInstitutionsDbContext ctx) => _ctx = ctx;

    public async Task<InstitutionInfoDto> Handle(GetInstitutionInfoQuery request, CancellationToken cancellationToken)
    {
        var institution = await _ctx
            .Institutions
            .Where(i => i.Id.Equals(request.Id))
            .Include(i => i.Students)
            .FirstOrDefaultAsync(cancellationToken);

        if (institution is null)
        {
            throw new NotFoundException($"Cannot find institution with ID: {request.Id}.");
        }

        var studentsInfo = institution.Students
            .Select(s => new StudentInfoDto(s.Id.Id, s.Name, s.RegistrationNumber.ToString(), s.DiscountType));

        return new InstitutionInfoDto(institution.Id.Id, institution.Code(), studentsInfo);
    }
}